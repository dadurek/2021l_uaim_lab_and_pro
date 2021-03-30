# USAGE

## Docker

In order to run project use `docker-compose.yml`. This will create:

* `doctors_db`  -  database for doctors
* `rooms_db` - database for examination-rooms
* `doctors` - micro data service for doctors
* `rooms` - micro data service for examination-rooms
* `roomselector` - micro app service for examination-rooms-selector

### Actions

1) To match rooms to doctors use: ```http://localhost:8080/examination-rooms-selection```
   
2) add doctor send json to: ```http://localhost:8080/add-doctor```
    * Json should work like:
        ```
          "firstName": "Test",
          "lastName": "Testowski",
          "sex": "Male",
          "specializations": [1,2]
        ```
        * `firstname` - string
        * `lastname` - string
        * `sex` - string, but only `Male` or `Female`
        * `specialization` - table of numbers
    
3) add room send json to: ```http://localhost:8080/add-room```
    * Json should work like:
        ```
        "number": "103a",
        "certifications": [4,5]
        ```
        * `number` - string
        * `certifications` - table of numbers   
    
------------------------------------------

## Local (not fully)

In order to run project you have to uncomment ports in database entries and then start databases from `docker-compose.yml` (`doctos_db` and `rooms_db` ). Next compile all micro services in DEBUG and everything should work.

### Actions

To perform any action use same url as in Docker.

<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/TRGLDXJ/ddd.jpg"> 
</p>
