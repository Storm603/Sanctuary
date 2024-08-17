var isActiveMap = false;
var map = null;
var markerControls = null;
var markerCollection = [];

document.getElementById('mapToggle').addEventListener('change', CheckBoxMapInitialization);
var appointmentMapFunctions = {
    initMap: async function () {
        console.log("im here");
        const { Map } = await google.maps.importLibrary("maps");

        map = new google.maps.Map(document.getElementById("map"), {
            zoom: 6,
            center: { lat: 42.7339, lng: 25.4858 },
            mapId: 'ddbac290e74a030f',
        });
    },
    centerAndZoomMap: async function (lat, lon, zoom) {
        var latLng = new google.maps.LatLng(lat, lon);
        map.panTo(latLng);
        map.setZoom(zoom);
    },
    removeMarkers: async function (markerCollection) {
        console.log('hello');

        for (var i = markerCollection.length - 1; i >= 0; i--) {
            markerCollection[i].setMap(null);
            markerCollection.pop();

            window[`marker${i}`] = undefined;
            delete window[`marker${i}`];
        }
    },
    insertGoogleMapApiLocationMarker: async function (detailedAddress, iteratedNumber) {
        markerCreationAndDetails.addMarkerWithEvent(detailedAddress, iteratedNumber);
    },
};

var markerCreationAndDetails = {
    addMarkerWithEvent: async function (detailedAddress, iteratedNumber) {
        // infowindow content
        let div = document.createElement('div');
        div.id = 'infoWindowScreen';
        div.classList = 'container d-flex flex-column justify-content-center';

        let div2 = document.createElement('div');
        div2.style = 'width:200px;  min-height:40px';
        div2.innerHTML = `<span> Address: ${detailedAddress.Country}, ${detailedAddress.Town}, ${detailedAddress.StreetName} </span>`;
        div2.classList = 'd-flex mb-auto pb-auto justify-content-left'



        let divButtonHolder = document.createElement('div');
        divButtonHolder.classList = 'd-flex flex-column justify-content-center ';
        divButtonHolder.style = 'margin: 4px;'

        let buttonAppCreation = document.createElement('button');
        buttonAppCreation.classList = 'btn btn-outline-primary text-center d-flex justify-content-center';
        buttonAppCreation.style = 'width:180px';
        buttonAppCreation.innerHTML = 'Create Appointment';

        divButtonHolder.appendChild(buttonAppCreation);

        div.appendChild(div2);
        div.appendChild(divButtonHolder);

        buttonAppCreation.addEventListener('click', () => {
            let url = new URL('https://localhost:44394/NormalUsers/Appointment/AppointmentDetails');
            url.searchParams.set('clinicName', detailedAddress.ClinicName)

            let buttonGroupBS = document.createElement('btn-group');
            buttonGroupBS.role = 'group';
            buttonGroupBS.classList = 'd-flex  justify-content-center';

            let positiveButton = document.createElement('a');
            positiveButton.style.width = '90px';
            positiveButton.innerHTML = '&#10003;';
            positiveButton.classList = 'btn btn-success';
            positiveButton.href = url;

            let negativeButton = document.createElement('button');
            negativeButton.style.width = '90px';
            negativeButton.innerHTML = '&#10005;';
            negativeButton.classList = 'btn btn-danger';

            buttonGroupBS.append(positiveButton, negativeButton);

            divButtonHolder.replaceChild(buttonGroupBS, buttonAppCreation);

            let spanWarning = document.createElement('span');
            spanWarning.innerHTML = 'upon confirmation you will be redirected to another page';
            spanWarning.style = 'font-size:8px; font-style: italic; text-align: center; margin-top: 3px; margin-bottom: -2px;'

            divButtonHolder.appendChild(spanWarning);

            positiveButton.addEventListener('click', () => {
                location.href = "";
            })

            negativeButton.addEventListener('click', () => {
                divButtonHolder.replaceChild(buttonAppCreation, buttonGroupBS);
                divButtonHolder.removeChild(spanWarning);
            })
        });


        //
        let infoWindow = new google.maps.InfoWindow({
            content: div,
        });

        window['marker' + iteratedNumber] = new google.maps.Marker({
            position: new google.maps.LatLng(detailedAddress.lat, detailedAddress.lon),
            map,
        });

        window['marker' + iteratedNumber].addListener("click", () => {
            infoWindow.open({
                anchor: window['marker' + iteratedNumber],
                map,
            })
        })

        markerCollection.push(window['marker' + iteratedNumber]);
    },
};


function CheckBoxMapInitialization(event) {
    let mapToggle = document.getElementById('map');

    if (event.target.checked == true) {
        if (!isActiveMap) {
            isActiveMap = true;
            appointmentMapFunctions.initMap();

            mapToggle.style.visibility = 'visible';

            mapToggle.classList.add('animatecss');

            setTimeout(() => {
                if (branchLocationDataKeeper.some(x => x.PostalCode === zipCodeValue)) {
                    for (var i = 0; i < branchLocationDataKeeper.length; i++) {
                        appointmentMapFunctions.insertGoogleMapApiLocationMarker(branchLocationDataKeeper[i], i)
                    }
                    return;
                }
                if (branchLocationDataKeeper && branchLocationDataKeeper.length > 0) {
                    for (var i = 0; i < branchLocationDataKeeper.length; i++) {
                        appointmentMapFunctions.insertGoogleMapApiLocationMarker(branchLocationDataKeeper[i], i)
                    }
                }

                if (selectedItemFromDropdown != '') {
                    appointmentMapFunctions.centerAndZoomMap(selectedItemFromDropdown.lat, selectedItemFromDropdown.lon, 15);
                }
            }, 1000);

            return;
        }
        mapToggle.classList.replace('animatecssreversed', 'animatecss');

        mapToggle.style.visibility = 'visible';
    }
    else {
        mapToggle.classList.replace('animatecss', 'animatecssreversed');

        setTimeout(() => {
            mapToggle.style.visibility = 'hidden';
        }, 800)
    }
}