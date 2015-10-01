function initialize() {

    // Initialiser la variable de location
    var latlng = new google.maps.LatLng(45.45990, -73.56727);
            
        var mapCanvas = document.getElementById('map');
        
        // Options de la carte
        var mapOptions = {
            center: latlng,
            zoom: 16,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        // Création de la map
        var map = new google.maps.Map(mapCanvas, mapOptions);
        
        // Création d'un marqueur
        var marker = new google.maps.Marker({
            position: latlng,
            map: map,
            title: 'Icosaèdre!'
        });
    }

google.maps.event.addDomListener(window, 'load', initialize);
