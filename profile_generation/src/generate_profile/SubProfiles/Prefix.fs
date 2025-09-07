module Prefix
open Domain

let requiredProfileProperties = [
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("@type",              Required, MANY,         [   (Schema.PropertyValue, END)], 
                                                                    "Schema.org class for the resource declared using JSON-LD syntax. For other serialisations please use the appropriate mechanism. While it is permissible to provide multiple types, it is preferred to use a single type.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("name",               Required, ONE,          [    (Schema.Text, END)
                                                                    ], 
                                                                    "MUST be 'Prefix'", 
                                                                    "**THIS PROFILE**")
    ProfileRow.create("value",              Required, ONE,          [   (Schema.Text, END)],
                                                                    "The CLI prefix of an input from a [Workflow Protocol profile](#workflow-protocol) described by a [FormalParameter](#formalparameter)", 
                                                                    "**THIS PROFILE**")
]

let recommendedProfileProperties = []

let optionalProfileProperties = []

let profile = Profile.create(
    name = "PropertyValue - Prefix",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)