var dropdownListItems = document.getElementById('dropdownItems');
var branchLocationDataKeeper = [];
var selectedItemFromDropdown = '';
var zipCodeValue = '';

$('#zipCodeTextField').on('input', function () {
    zipCodeValue = $('#zipCodeTextField').val();

    appointmentMapFunctions.removeMarkers(markerCollection);

    dropdownListItems.innerHTML = '';
    dropdownListItems.style.display = 'none';

    if (!zipCodeValue)
    {
        if (map) {
            appointmentMapFunctions.centerAndZoomMap(42.7339, 25.4858, 6);
        }
        return;
    }

    FetchLocationData(zipCodeValue);
});

function FetchLocationData(postalCode) {
    $.ajax(
        {
            type: 'GET',
            url: 'https://localhost:7253/GetAppointmentSearchBarSuggestions/' + postalCode,
            success: function (incomingData) {
                branchLocationDataKeeper = incomingData;

                PopulateAppointmentDropdown();
                dropdownListItems.style.display = 'grid';
            },

            error: function (error) { console.log(error) }
        })
};

function PopulateAppointmentDropdown() {
    for (var i = 0; i < branchLocationDataKeeper.length; i++) {
        let listElement = document.createElement('li');
        listElement.style = 'display: grid; pointer-events: auto;';

        let addressSpan = document.createElement('span');
        addressSpan.textContent = `${branchLocationDataKeeper[i].StreetName}, ${(branchLocationDataKeeper[i].District == null ? '-' : branchLocationDataKeeper[i].District)}, ${branchLocationDataKeeper[i].Town}, ${branchLocationDataKeeper[i].Country}, ${branchLocationDataKeeper[i].PostalCode}`;
        addressSpan.style = 'font-size: 0.8em; letter-spacing: 1px; pointer-events: none;';

        let bClinicName = document.createElement('span');
        bClinicName.textContent = `${branchLocationDataKeeper[i].ClinicName}`;
        bClinicName.style = 'pointer-events: none;';

        let specificInfo = document.createElement('p');
        specificInfo.textContent = `${branchLocationDataKeeper[i].PostalCode}, ${branchLocationDataKeeper[i].lat}, ${branchLocationDataKeeper[i].lon}`
        specificInfo.style = 'display: none; pointer-events: none;';
        specificInfo.setAttribute('id', 'specificInfo');

        let indexedElementInBranchLocationDataKeeper = document.createElement('p');
        indexedElementInBranchLocationDataKeeper.textContent = i;
        indexedElementInBranchLocationDataKeeper.style = 'display: none; pointer-events: none;';
        indexedElementInBranchLocationDataKeeper.setAttribute('id', 'selectElementIndex')

        listElement.appendChild(addressSpan);
        listElement.appendChild(bClinicName);
        listElement.appendChild(specificInfo);
        listElement.appendChild(indexedElementInBranchLocationDataKeeper);

        dropdownListItems.appendChild(listElement);

        if (map) {
            appointmentMapFunctions.insertGoogleMapApiLocationMarker(branchLocationDataKeeper[i], i);
        }
    }
}

document.getElementById('dropdownItems').addEventListener('click', selectElementFromDynamicDropdown);

function selectElementFromDynamicDropdown(event) {
    // event.target.childNodes = [0] - spanAddressDetails, [1] - spanClinicName, [2] - hiddenParagraphWithCoordinates, [3] - indexed element in branchLocationDataKeeper array for easier data transfer
    selectedItemFromDropdown = branchLocationDataKeeper[event.target.childNodes[3].textContent];

    if (event.currentTarget.contains(event.target)) {
        let zipCodeTextField = document.getElementById('zipCodeTextField');

        zipCodeTextField.value = selectedItemFromDropdown.PostalCode;

        if (map) {
            appointmentMapFunctions.centerAndZoomMap(selectedItemFromDropdown.lat, selectedItemFromDropdown.lon, 15);
        }

        dropdownListItems.innerHTML = '';
        dropdownListItems.style.display = 'none';
    }
}