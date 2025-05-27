module WorkflowInput
open Domain

let requiredProfileProperties = [
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("@type",              Required, MANY,         [   (Schema.PropertyValue, END)], 
                                                                    "Schema.org class for the resource declared using JSON-LD syntax. For other serialisations please use the appropriate mechanism. While it is permissible to provide multiple types, it is preferred to use a single type.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("additionalType",     Required, ONE,          [    (Schema.Text, OR)
                                                                         (Schema.URL, END)
                                                                    ], 
                                                                    "MUST be 'Workflow Input' or ontology term to identify it as a Workflow Input", 
                                                                    "**THIS PROFILE**")
    ProfileRow.create("exampleOfWork",      Required, ONE,          [   (IRI, END)], 
                                                                    "Identifier of the FormalParameter instance realized by this entity - intended to describe realization of `input`s of [Workflow Protocols](#workflow-protocol) in [Workflow Invocations](workflow-invocation). MUST refer to a `input` of a [Workflow Protocol](#workflow-protocol) to distinguish from inputs that are process parameters.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("value",              Required, ONE,          [   (Schema.Boolean, OR)
                                                                        (Schema.Number, OR)
                                                                        (Schema.StructuredValue, OR)
                                                                        (Schema.Text, END)
                                                                    ],
                                                                    "The value of a QuantitativeValue (including Observation) or property value node. For QuantitativeValue and MonetaryAmount, the recommended type for values is 'Number'. For PropertyValue, it can be 'Text', 'Number', 'Boolean', or 'StructuredValue'. Use values from 0123456789 [Add to Citavi project by ISBN] (Unicode 'DIGIT ZERO' (U+0030) to 'DIGIT NINE' (U+0039)) rather than superficially similar Unicode symbols. Use '.' (Unicode 'FULL STOP' (U+002E)) rather than ',' to indicate a decimal point. Avoid using these symbols as a readability separator.", 
                                                                    "https://schema.org/PropertyValue")
]

let recommendedProfileProperties = [
    // Required -> Recommended
    ProfileRow.create("name",               Required, ONE,       [   (Schema.Text, END)], 
                                                                    "The name of the item.", 
                                                                    "https://schema.org/Thing")
]

let optionalProfileProperties = []

let profile = Profile.create(
    name = "PropertyValue - WorkflowInput",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)