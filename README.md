# Parkster
A web Api for parkings
#This is only a small web api test that uses a local database to store information about vehicles/ parking spaces and the parking itself.
#To test it use for example Postman.

To create a new vehicle this is what you need to post in the body: (https://localhost:44328/api/vehicles)
{  
"registrationNumber": "abc123",  
"owner": "Jane Doe"
}

To post a new location, post the following: (https://localhost:44328/api/locations)
{
	"name" : "Sesame Street 1-24",
	"pricePerMinute" : 1.25
}

To view what parkings for a specific vehicle you make a GET -request with vehicle-id / parkings as such;
https://localhost:44328/api/vehicles/1/parkings
