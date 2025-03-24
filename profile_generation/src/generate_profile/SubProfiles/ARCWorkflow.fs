module ARCWorkflow
open Domain

let requiredProfileProperties = []
let recommendedProfileProperties = []
let optionalProfileProperties = []

let profile = Profile.create(
    name = "ARCWorkflow",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)