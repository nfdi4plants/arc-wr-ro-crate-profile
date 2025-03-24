module ARCRun

open Domain

let requiredProfileProperties = []
let recommendedProfileProperties = []
let optionalProfileProperties = []

let profile = Profile.create(
    name = "ARCRun",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)