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
            $("#Latitud").val(marker.position.lb);
            $("#Longitud").val(marker.position.mb);
        } else {
            marker = new google.maps.Marker({
                position: location,
                map: map
            });
            $("#Latitud").val(marker.position.lb);
            $("#Longitud").val(marker.position.mb);
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

    
    $.getJSON("/Alarma/GetAlamasCliente", {
        clienteId: clienteid,
    }).done(function(data) {
        $.each(data, function (i, item) {
            var mak = new google.maps.Marker({
                position: new google.maps.LatLng(item.Latitud, item.Longitud),
                map: map,
                title:'Alarma Nro: ' + item.AlarmaId
            });
               
        });
    });    

};


