function GoogleMapListener() {
    var mapOptions = {
        center: new google.maps.LatLng(-31.252652821252568, -61.491824984550476),
        zoom: 14,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"),
        mapOptions);
    var marker;

    function placeMarker(location) {
        if (marker) {
            marker.setPosition(location);
            $("#Latitud").val(marker.position.nb);
            $("#Longitud").val(marker.position.ob);
        } else {
            marker = new google.maps.Marker({
                position: location,
                map: map
            });
            $("#Latitud").val(marker.position.ob);
            $("#Longitud").val(marker.position.nb);
        }
    }

    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });
};

function GoogleMap(clienteid) {
    mapOptions = {
        center: new google.maps.LatLng(-31.252652821252568, -61.491824984550476),
        zoom: 14,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"),
        mapOptions);





    var pinIcon = new google.maps.MarkerImage(
        '../Content/Themes/AsegurarSA/img/policia.png',
        null, /* size is determined at runtime */
        null, /* origin is 0,0 */
        null, /* anchor is bottom center of the scaled image */
        new google.maps.Size(32, 38)
    );
    $.getJSON("/Alarma/GetComisarias")
        .done(function (data) {
            $.each(data, function (i, item) {
                var mak = new google.maps.Marker({
                    position: new google.maps.LatLng(item.Latitud, item.Longitud),
                    map: map,
                    title: item.Descripcion,
                    icon:pinIcon//'../Content/Themes/AsegurarSA/img/policia.png'
                });
            });
        });
    
    $.getJSON("/Alarma/GetAlamasCliente",{clienteid:clienteid})
        .done(function (data) {
            $.each(data, function (i, item) {
                debugger;
                var mak = new google.maps.Marker({
                    position: new google.maps.LatLng(item.Latitud, item.Longitud),
                    map: map,
                    title: item.AlarmaId,
                });
            });
        });
};


