# Lead Management Design Decisions

## Web Service Design
* REST API
* .Net core 3.1
* Postgres DB as a document store (NoSQL)
* Entity Framework
* Simple implementation of CQRS.  The commands and queries are separate, but at this time only one database table is used and there is no event sourcing.  The idea is that this design can easily be extended to cater for a fuller implementation of CQRS.
* Repository pattern
* Hexagonal architecture which should be visible in the storage layer.  It should be relatively simple to completely replace the storage layer without affecting too much code in the service.
* TDD used to develop all functionality in the service.
* Dependency Injection

## SPA Design
* React
* Typescript
* Functional components
* React hooks
* As little as possible logic in the ui relying on the web service queries to return all the data in the correct format to be displayed
* Loose coupling by creating separate views for each tab even though many aspects of the ui were the same.  Although this is not too DRY, it does mean that if one of the views needs to change then the other will not be impacted.

## Things I would have done differently if I had more time
#### React App
* It would be better if hypermedia was used for the action requests that are sent from the ui (accept and decline)
* The network requests in the ui are:
    * directly in the components
    * not getting the service url from config
    * not handling errors well or informing the user
* Styles are passed from the root to the children.  I really struggled trying to get the styles working another way, but I think the combination of functional components and typescript made it difficult.  I am sure there is a much better way to do this.
* Testing in the ui:
    * I started out using TDD in the front-end and built out nearly all the functionality covered by tests.  Then I added layout and styling and broke all the tests and never had a chance to fix them.

#### Web Service
* Json Api for requests and responses
* Using the mediator pattern to automatically connect the requests to the handlers, thereby reducing dependencies.
* The connection string is hard-coded instead of being inserted via environment variables
* There is no secret management
* There is no authentication or authorisation
* There is no middleware to generically handle logging and errors
* Did not have time to implement events in the domain.  It would have been good to raise a LeadAcceptedEvent and then the handler for this event would have performed actions like sending the email.
* Discount % is currently hard-coded, this should be configurable.
