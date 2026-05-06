# Miniature Electronic Health Record Demo
## Exploring Entity Framework Core with a Subset of the HL7 Reference Information Model (RIM)

This repository demonstrates how to use Entity Framework Core in C# to model, persist, and query a simplified Electronic Health Record (EHR) using core classes from the HL7 Reference Information Model (RIM).

The goal is to illustrate how a coherent, navigable subset of the RIM—Entity, Role, Act, and Participation—can be represented idiomatically in EF Core and used to build a small but realistic clinical data graph.
##📘 Overview
HL7 RIM describes healthcare information using four foundational abstractions:
    Entity — a physical thing (person, organization, device, material)
    Role — the capacity in which an Entity participates (patient, provider, manufactured product)
    Act — something that happens (observation, encounter, procedure)
    Participation — the link between a Role and an Act (performer, subject, author)
    ActRelationship - how two different acts are related (observation after a procedure)
    RoleLink - How two different roles are related (Provider to a Patient)
Click [here](https://lucid.app/lucidchart/a3a7549f-9f4d-437d-bc0b-2b082bc3a176/edit?viewport_loc=315%2C-692%2C3401%2C1428%2C0_0&invitationId=inv_49d68ca2-b012-4b96-b9fd-509214a74e34) for a UML diagram of the objects mentioned above,
This demo shows how these concepts map into EF Core entities, relationships, and navigation properties. 

It is not intended for production use, but it provides a solid conceptual and technical foundation for understanding HL7‑style systems.
