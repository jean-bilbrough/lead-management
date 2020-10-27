# Lead Management App
A lead management application for tradies

## Getting Started
#### Prerequistes
* Docker - ([Mac](https://docs.docker.com/docker-for-mac/install/)) ([Windows](https://docs.docker.com/docker-for-windows/install/))

#### Steps
1. Clone this repository
2. Change to the src directory
	```
	cd lead-management/src
	```
3. Build and run docker
    ```
    docker-compose up -d --build
    ```
4. Once complete, there will be 3 containers running
    * postgres db
    * lead management service at http://localhost:5000/ 
    * lead management ui at http://localhost:3000/

5. Navigate in your browser to the UI and explore the features
    ```
    http://localhost:3000/
    ```

6. The database is automatically seeded with 3 leads when the service starts to run.  If you would like to clear your changes and start again, then pull down the containers
    ```
    docker-compose down
    ```

7. And up them again
    ```
    docker-compose up -d
    ```

#### Disclaimer
* This has been tested on a Mac and not on a Windows machine.  It should work but if there are issues, then let me know.