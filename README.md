# Dapr Sample Rafael Willwohl Salgado

The solution has 4 projects that help to apply the DDD with clean architecture and solid principles.
It's using the Dapr cache store, so to run it please install the Dapr CLI https://docs.dapr.io/getting-started/install-dapr-cli/ 

# Assumptions 

the rule to set default values is a validation for the application is not a domain business rule

the rule regarding a page bigger than 10 items was processed as a domain business rule

the header validation was implemented inside a middleware

and the unit tests at this stage only validate the main business rules regarding the application service and domain context


