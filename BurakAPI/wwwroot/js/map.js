
    var myLatLng = {lat: 36.8841, lng: 30.7056 };
    var mapOptions = {
        center: myLatLng,
    zoom: 7,
    mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById('googleMap'), mapOptions);

    var directionsService = new google.maps.DirectionsService();
    var directionsDisplay = new google.maps.DirectionsRenderer();

    directionsDisplay.setMap(map);

function calcRoute() {
    var baslangicAdres = document.getElementById("BaslangicAdres").value;
    var varisAdres = document.getElementById("VarisAdres").value;

    var request = {
        origin: baslangicAdres,
        destination: varisAdres,
        travelMode: google.maps.TravelMode.DRIVING,
        unitSystem: google.maps.UnitSystem.METRIC
    };

    directionsService.route(request, function (result, status) {
        if (status === google.maps.DirectionsStatus.OK) {
            // Mesafeyi ve alacağı zamanı alınan yer.
            const output = document.querySelector("#output");
            output.innerHTML = "<div class='alert-info'>Başlangıç: " + baslangicAdres + ".<br />Varış: " + varisAdres + "<br /> Araç ile Mesafe <i class='fa-solid fa-road'></i>: " + result.routes[0].legs[0].distance.text + "<br />Toplam Varış Süresi: <i class='fa-solid fa-hourglass-start'></i>: " + result.routes[0].legs[0].duration.text + ".</div>";

            directionsDisplay.setDirections(result);
        } else {
            directionsDisplay.setDirections({ routes: [] });

            // Haritayı ortala
            map.setCenter(myLatLng);

            // Hata mesajı gösterme
            output.innerHTML = "<div class='alert-danger'><i class='fa-solid fa-triangle-exclamation'></i> Sürüş Mesafesi Alınamadı.</div>";
        }
    });

}
    var options = {
        types: ['geocode']
    };
    var input1 = document.getElementById("BaslangicAdres");
    var autocomplete = new google.maps.places.Autocomplete(input1, options);

    var input2 = document.getElementById("VarisAdres");
    var autocomplete2 = new google.maps.places.Autocomplete(input2, options);

    document.addEventListener("keyup", function (event) {
        if (event.key === "Enter") {
        calcRoute();
        }
    });

    var swapButton = document.getElementById("swapButton");

    swapButton.addEventListener("click", function () {
        var temp = BaslangicAdres.value;
    BaslangicAdres.value = VarisAdres.value;
    VarisAdres.value = temp;
    });

