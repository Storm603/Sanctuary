var appointmentMapFunctions = {
    initMap: function () {
        const myLatLng = { lat: 42.7339, lng: 25.4858 };
        const map = new google.maps.Map(document.getElementById("map"), {
            zoom: 7,
            center: myLatLng,
        });

        //new google.maps.Marker({
        //    position: myLatLng,
        //    map,
        //    title: "Hello World!",
        //});
    },
    getGeoInfoForONETownFromDropdownMenu: function () {
        $.ajax({
            type: "GET",
            url: 'Area/NormalUsers/Controllers/Appointment/GetLatitudeAndLongtituteInfo',
            data: { string: townName },
            dataType: "text",
            success: function (data) {
                return data;
            },
            error: function (req, status, error) {
                console.log(msg);
            }
        });
    }
}

let test = 5;
window.initMap = appointmentMapFunctions.initMap;