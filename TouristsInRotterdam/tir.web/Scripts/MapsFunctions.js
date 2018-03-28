var map;
function initMap() {

	var tirStyle =	[
		{
		  "elementType": "labels",
		  "stylers": [
			{
			  "visibility": "off"
			}
		  ]
		},
		{
		  "featureType": "administrative.land_parcel",
		  "stylers": [
			{
			  "visibility": "off"
			}
		  ]
		},
		{
		  "featureType": "administrative.neighborhood",
		  "stylers": [
			{
			  "visibility": "off"
			}
		  ]
		}
	  ]
	map = new google.maps.Map(document.getElementById('map'), {
		center: { lat: 51.9182711, lng: 4.4791135 },
		zoom: 12,
		styles: tirStyle
	});

	// TODO: Set labels from POI type
	var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

	// TODO: Add info for hover
	// TODO: Make clickable for navigation
	var markers = locations.map(function (location, i) {
		return new google.maps.Marker({
			position: location,
			label: labels[i % labels.length]
		});
	});

	var markerCluster = new MarkerClusterer(map, markers, { imagePath: 'img/m' });
}

// TODO: Get locations from DB
var locations = [
	{ lat: 51.9244201, lng: 4.4777326 },
	{ lat: 51.9159124, lng: 4.4788838 },
	{ lat: 51.9210251, lng: 4.4787017 }
]