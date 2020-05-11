# REST API Roulette Game

This is a Api for the game roulette with the option to do bets.

The entire application is contained within the `RouletteApi` directoy.

You can see `http://localhost:5000/swagger/index.html` runs a the API
documentation below.


## Install

    dotnet build 
    

## Run the app

    dotnet run


# REST API

The REST API to Roulete is described below.

## Get list of Roulettes

### Request

`GET api/roulette`

    curl -X GET "http://localhost:5000/api/Roulette" -H "accept: application/json"

### Response

    content-length: 497 
 	content-type: application/json; charset=utf-8 
 	date: Mon, 11 May 2020 16:56:50 GMT 
 	server: Microsoft-IIS/10.0 
 	x-powered-by: ASP.NET 
    Response Body:
    [
    	{
    		"id": 1,
    		"status": true,
    		"createdAt": "2020-05-09T14:55:57.41"
  		},
  		{
    		"id": 2,
    		"status": false,
    		"createdAt": "2020-05-09T18:02:20.36"
  		}
    ]

## Create a new Roulette

### Request

`POST /api/Roulette`

    curl -X POST "http://localhost:5000/api/Roulette" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"id\":0,\"status\":true}"

### Response

     content-length: 63 
 	content-type: application/json; charset=utf-8 
 	date: Mon, 11 May 2020 17:01:35 GMT 
 	location: http://localhost:5000/api/Roulette/2002 
 	server: Microsoft-IIS/10.0 
 	x-powered-by: ASP.NET
    Response body:
    {
  		"id": 2002,
  		"status": true,
  		"createdAt": "2020-05-11T12:01:35.687"
	}


## Get a specific Roulette

### Request

`GET /api/roullete/{id}`

    curl -X GET "http://localhost:5000/api/Roulette/1" -H "accept: application/json"

### Response

    content-length: 59 
 	content-type: application/json; charset=utf-8 
 	date: Mon, 11 May 2020 17:03:53 GMT 
	server: Microsoft-IIS/10.0 
	x-powered-by: ASP.NET
    Response body:
    {
 		"id": 1,
  		"status": true,
  		"createdAt": "2020-05-09T14:55:57.41"
	}

## Update status of Roulette

### Request

`PATCH api/roulette/{id}`

    curl -X PATCH "http://localhost:5000/api/Roulette/1" -H "accept: */*" -H "Content-Type: application/json" -d "[{\"value\":false,\"path\":\"status\",\"op\":\"replace\"}]"
### Response

    date: Mon, 11 May 2020 17:08:05 GMT 
 	server: Microsoft-IIS/10.0 
 	transfer-encoding: chunked 
 	x-powered-by: ASP.NET 
	Response status: 200
    

## Get list of Bets to specific Roulette

### Request

`GET api/bet/{id}`

    curl -X GET "http://localhost:5000/api/Bet/2" -H "accept: application/json"

### Response

    content-length: 181 
 	content-type: application/json; charset=utf-8 
 	date: Mon, 11 May 2020 17:11:53 GMT 
	server: Microsoft-IIS/10.0 
 	x-powered-by: ASP.NET
    Response body:
    [
  		{
    		"betId": 4,
    		"color": null,
    		"number": 12,
    		"amount": 1560,
    		"createdAt": "2020-05-10T13:44:22.683"
  		},
  		{
    		"betId": 5002,
    		"color": null,
    		"number": 25,
    		"amount": 1000,
    		"createdAt": "2020-05-10T20:07:47.27"
  		}	
	]

## Create a Bet to specific Roulette

### Request

`POST api/bet`

    curl -X POST "http://localhost:5000/api/Bet" -H "accept: application/json" -H "Content-Type: application/json" -d "{\"rouletteId\":1004,\"color\":\"red\",\"amount\":950}"

### Response

    date: Mon, 11 May 2020 17:16:53 GMT 
 	server: Microsoft-IIS/10.0 
 	transfer-encoding: chunked 
 	x-powered-by: ASP.NET
    Response status: 200


## Close Bets to specific Roulette

### Request

`GET api/bet/close/{id}`

    curl -X GET "http://localhost:5000/api/Bet/close/1004" -H "accept: application/json"

### Response

    content-length: 189 
 	content-type: application/json; charset=utf-8 
 	date: Mon, 11 May 2020 17:19:21 GMT 
 	server: Microsoft-IIS/10.0 
 	x-powered-by: ASP.NET
    Response Body:
    [
  		{
    		"betId": 8002,
    		"color": "red",
    		"number": null,
    		"amount": 950,
    		"createdAt": "2020-05-11T12:16:24.453"
  		},
  		{
    		"betId": 8003,
    		"color": "red",
    		"number": null,
    		"amount": 950,
    		"createdAt": "2020-05-11T12:16:53.673"
  		}
	]
    Connection: close
