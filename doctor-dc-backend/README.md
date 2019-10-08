This is Doctor Diagnosis Portal Backend Repository

## Dockerfile
Use the command docker build -t <imageName> .


## docker-compose
Use the command docker-compose up

## Added Seed Data for the Doctors Portal to test the Doctor APi
### to load the seed-data into the Database
Run the following scripts from seed-data folder as the directory
$ mongo
$ load(".seedDataForApi/data.js")