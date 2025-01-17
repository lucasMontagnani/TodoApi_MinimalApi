# TodoApi_MinimalApi

This project is a simple Todo aplication as an example of a Minimal API (Rest).

It uses a In-Memory database and counts with a dockerfile to containerize the aplication with docker.

This API counts with the following endpoints:
- (GET)    /TodoItem       -> Get all to-do items;
- (GET)    /TodoItem/{id}  -> Get a to-do by id;
- (POST)   /TodoItem       -> Create a new to-do;
- (PUT)    /TodoItem/{id}  -> Update an existing to-do by id;
- (DELETE) /TodoItem/{id}  -> Remove a to-do from the database;
