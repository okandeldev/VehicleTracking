# VehicleTracking
Vehicle Tracking  - .Net core Microservices
 
## Scenario:

Imagine you are one of our consultants and you got assigned to a project at one of our top partners.
They have a number of connected vehicles that belongs to a number of customers.
They have a need to be able to view the status of the connection among these vehicles on a monitoring display.
The vehicles send the status of the connection one time per minute.
The status can be compared with a ping (network trace); no request from the vehicle means no connection.
So, vehicle is either Connected or Disconnected.

## Task:

- Your task will be to create a data store that keeps these vehicles with their status and the customers who own them, as well as a GUI (preferably web-based) that displays the status.
- Obviously, for this task, there are no real vehicles available that can respond to your "ping" request.
- This can either be solved by using static values or ​​by creating a separate machinery that returns random fake status.

## Requirements

1. Web GUI (Single Page Application Framework/Platform).
   - An overview of all vehicles should be visible on one page (full-screen display), together with their status.
   - It should be able to filter, to only show vehicles for a specific customer.
   - It should be able to filter, to only show vehicles that have a specific status.
2. Random simulation to vehicles status sending.
3. If database design will consume a lot of time, use data in-memory representation.
4. Unit Testing.
5. .NET Core, Java or any language you feel comfortable with.
6. Complete analysis for the problem.
   - Full architectural sketch to solution.
   - Analysis behind the solution design, technologies....
   - How to run your solution.
7. Use CI (Travis, Circle, TeamCity...) to verify your code (Static analysis,..) and tests.
8. Dockerize the whole solution.
9. Use Microservices architecture.
   - Use any Microservices Chassis Framework.
10. Use any free tier on any cloud platform like: - AWS, Azure or GCP

## Optional Requirements

1. Write an integration test.
2. Write an automation test.
3. Explain if it is possible to be in Serverless architecture and how?
4. Continuous delivery to the solution to the cloud.

## Data:

Below you have all customers from the system; their addresses and the vehicles they own.

### Customer #1:

**Kalles Grustransporter AB**

**Cementvägen 8, 111 11 Södertälje**

| VIN (VehicleId)   | Reg. nr. |
| ----------------- | -------- |
| YS2R4X20005399401 | ABC123   |
| VLUR4X20009093588 | DEF456   |
| VLUR4X20009048066 | GHI789   |

### Customer #2:

**Johans Bulk AB**

**Balkvägen 12, 222 22 Stockholm**

| VIN (VehicleId)   | Reg. nr. |
| ----------------- | -------- |
| YS2R4X20005388011 | JKL012   |
| YS2R4X20005387949 | MNO345   |

### Customer #3:

**Haralds Värdetransporter AB**

**Budgetvägen 1, 333 33 Uppsala**

| VIN (VehicleId)   | Reg. nr. |
| ----------------- | -------- |
| VLUR4X20009048066 | PQR678   |
| YS2R4X20005387055 | STU901   |

# Solution

## Architecture
This solution is built using **Microservices Architecture**, which is one of the most suitable architecture that matches this business use case. It allows decomposing the application into different smaller services that improves modularity and scalability of services independently. It fits for Cloud deployments and introducing new services to the plateform.

![Reference Image](/images/diagram.png)

## Services and Technologies

Application is a set loosely coupled services that communicate to each other over HTTP protocol.

- **Customers API:**  is a service for Customers management. 
    - **Technologies** :.Net Core, Postgres Database.
- **Vehicles API:** is a service for Vehicles management. 
    - **Technologies** : .Net Core, Postgres Database.
- **TrackingA API:** is a service for Tracking Vehicles, it receives Status of Vehicles and publish it to message Queue.Then the status is saved to Monogo DB and published to clients using SignalR. 
    - **Technologies** : .Net Core, Mongo DB, rabbitmq and Swagger.
- **Gateway API:** a  service where all calls to other service should come through. 
    - **Technologies** : .Net Core and Oclet.

- **Vehicle Ping Simulator:** applciation that simulates vehicle's pings. 
    - **Technologies** : .Net Core. using Background Services
 
- **Vehicle Tracking UI:** a web application for displaying vehicles' realttime status. 
    - **Technologies** : Angular and Material Design.

## Deployment

### Development Environment

To fit with microservices architecture. **Docker** technology is used for local deployment.
 
#### Run Application

```shell
> docker-compose  -f docker-compose.yml -f docker-compose.override.yml up --build -d 

```

#### App URL

Vehicle Monitoring Dashboard: [http://localhost:8004/home](http://localhost:8004/home 'http://localhost:8004/home')
 
![Reference Image](/images/UI.png)

#### API Documention

- **Customer API:** [http://localhost:9092/swagger-ui.html](http://localhost:9092/swagger-ui.html 'http://localhost:9092/swagger-ui.html')
  

![Reference Image](/images/CustomerAPI.png)

- **Vehicle API:** [http://localhost:9091/swagger-ui.html](http://localhost:9091/swagger-ui.html 'http://localhost:9091/swagger-ui.html')

![Reference Image](/images/CustomerAPI.png)

- **Tracking API:** [http://localhost:9093/swagger-ui.html](http://localhost:9093/swagger-ui.html 'http://localhost:9093/swagger-ui.html')


![Reference Image](/images/TrackingAPI.png)

## Production Environment

- **Azure AKS :** for services containers. [Pending]

## CI/CD

- **Azure PipeLine :** for CI/CD [Pending]



   