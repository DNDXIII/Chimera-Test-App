# Chimera-Test-App


To run the project you can use docker:

```
Docker-compose build
Docker-compose up
```

You may have to run the “up” command more than one time due to the migrations not working sometimes, which I did not spend time fixing since I guess that is not the point of the test :)

You can access the app through the following endpoints: 

* GET -> localhost:5001/api/Users : See the users and their scores
* POST -> localhost:5001/api/Users : Add a user. Body should be of style ->  {"username”:"Manuel”}
* DELETE -> localhost:5001/api/Users/{id} : Delete a user
* POST -> localhost:5001/api/Users/{username}/Scores : Add a new score to the user. Body should be of style -> {"finalScore":652}
* GET -> localhost:5001/api/Leaderboards : Check the leaderboards. Returns the users ordered by their best score. 
