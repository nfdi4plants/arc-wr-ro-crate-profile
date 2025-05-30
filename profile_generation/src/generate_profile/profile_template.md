# ARC Workflow Run RO-Crate Profiles

* Version: [[VERSION]]
* Permalink: https://doi.org/10.5281/zenodo.13734332
* Authors
  * Caroline Ott - https://orcid.org/0000-0003-1512-9504
  * Florian Wetzels - https://orcid.org/0000-0002-5526-7138
  * Lukas Weil - https://orcid.org/0000-0003-1945-6342
  * Kevin Schneider - https://orcid.org/0000-0002-2198-5262
* Table of Contents
  * [Overview](#overview)
  * [Requirements](#requirements)
    * [ARC Workflow](#arc-workflow)
    * [Workflow Protocol](#workflow-protocol)
    * [ARC Run](#arc-run)
    * [Workflow Invocation](#workflow-invocation)
    * [FormalParameter](#formalparameter)
    * [PropertyValue](#propertyvalue)
      * [PropertyValue - Workflow Input](#propertyvalue---workflow-input)
    * [SoftwareApplication](#softwareapplication)
  * [Compatibility with underlying profiles](#compatibility-with-underlying-profiles)
  * [Workflow Run Crate configuration in ARCs](#workflow-run-crate-configuration-in-arcs)
  * [Example ro-crate-metadata.json](#example-ro-crate-metadatajson)
    * [Minimal required fields](#minimal-required-fields)
      * [Workflow Profile](#workflow-profile)
      * [Workflow Run Profile](#workflow-run-profile)
    * [Minimal required fields with metadata](#minimal-required-fields-with-metadata)
      * [CWL Workflow Profile](#cwl-workflow-profile)
      * [Workflow Run Profile](#workflow-run-profile-1)
    * [Workflow Run RO-Crate compliant example](#workflow-run-ro-crate-compliant-example)
      * [Workflow Profile](#workflow-profile-1)
      * [Workflow Run Profile](#workflow-run-profile-2)

## Overview

The **ARC Workflow Run (arc-wr) RO-Crate Profiles** are a collection of profiles to describe both _`prospective`_ (**workflows**, yet to be executed) and _`retrospective`_ (**runs**, already executed) provenance of the orchestration of computational workflows in [Annotated Research Contexts (ARCs)](https://arc-rdm.org).
The profiles are designed to be re-usable in other profile collections and do not need to describe root entities of an RO-crate.

Computational and laboratory workflows share many similarities, but typically only differ in how they are executed.
In an ARC, the latter are described using the [ISA](https://isa-specs.readthedocs.io/en/latest/isajson.html#) model, separating between a workflow description ([`LabProtocol`](https://bioschemas.org/types/LabProtocol/0.5-DRAFT)) and its execution ([`LabProcess`](https://bioschemas.org/types/LabProcess/0.1-DRAFT)).
These types provide properties to annotate parameterized metadata in the form of key-value pairs using ontology terms.
For computational workflows, workflow descriptions are usually called _workflows_, and their execution is usually coined as a _run_ of said workflow.
**arc-wr** profiles aim to extend established workflow and run profiles to share the same process model as the ISA model, allowing for integration of computational and laboratory workflows in ARCs.
Advantages in regards to provenance include uniform queries, metadata enrichment, or visualization.

**arc-wr** profiles combine a selection of existing profiles, mainly the [Workflow Run Crate (WRC)](https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/) profile collection (which itself combines [Process Run Crate](https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate/) and [Workflow RO-Crate](https://about.workflowhub.eu/Workflow-RO-Crate/)) and extends it by providing means to annotate additional metadata and align terminology with other parts of an ARC.
Therefore, the main purpose of the **arc-wr** profiles is to merge the workflows and runs described by the **WRC** with the `LabProtocol` and `LabProcess` profiles formulated in the [ISA RO Crate Profile](https://doi.org/10.5281/zenodo.13748893) collection, creating a cohesive process model that tracks prospective and retrospective provenance of computational and laboratory workflows.
To allow for the ARC's _immutable but evolving_ nature, **arc-wr** profiles are in general less strict than the underlying profiles, relaxing requirements for many mandatory fields.
However, compatibility is guaranteed when following **both** the Mandatory and Recommended fields of the underlying profiles (see also the [compatibility section](#compatibility-with-underlying-profiles)).

The 4 main entities described by the **arc-wr** profiles are:

* [**`ARC Workflow`**](#arc-workflow)
  * A `Dataset` container object that describes a `workflow folder` inside an ARC.
  * Can be used to enrich a [`Workflow Protocol`](#workflow-protocol) with additional ISA metadata.
  * Contains a `mainEntity` following the [`Workflow Protocol` profile](#workflow-protocol) that describes the _Main Workflow_ of this `workflow folder`, analogous to [Workflow RO Crates](https://about.workflowhub.eu/Workflow-RO-Crate/).
  * Can be a valid [Workflow RO Crate](https://about.workflowhub.eu/Workflow-RO-Crate/), see the [Compatibility section](#compatibility-with-underlying-profiles).
* [**`Workflow Protocol`**](#workflow-protocol)
  * Contains prospective metadata of a workflow, e.g. descriptions of inputs and outputs.
  * A Multi-type object of the types [`MediaObject`](https://schema.org/MediaObject), [`SoftwareSourceCode`](https://schema.org/SoftwareSourceCode), [`ComputationalWorkflow`](https://bioschemas.org/types/ComputationalWorkflow/1.0-RELEASE), and [`LabProtocol`](https://bioschemas.org/types/LabProtocol). It represents the union of computational and laboratory workflow description.
  * Can represent a _Main Workflow_ (`main entity`) of a [Workflow RO Crate](https://about.workflowhub.eu/Workflow-RO-Crate/) following the [bioschemas ComputationalWorkflow profile](https://bioschemas.org/profiles/ComputationalWorkflow/1.0-RELEASE), extended with `LabProtocol` metadata (see also the [Compatibility section](#compatibility-with-underlying-profiles)).
* [**`ARC Run`**](#arc-run)
  * A `Dataset` container object that describes a `run folder` inside an ARC.
  * Can be used to enrich [`Workflow Invocations`](#workflow-invocation) with additional ISA metadata.
* [**`Workflow Invocation`**](#workflow-invocation)
  * A Multi-type object of the types [`CreateAction`](https://schema.org/CreateAction) and [`LabProcess`](https://bioschemas.org/types/LabProcess/0.1-DRAFT). It represents the union of computational and laboratory workflow execution.
  * Represents the invocation of a `Workflow Protocol` with actual values for the parameter slots of the executed `Workflow Protocol`.

They are connected via the following relations:

```mermaid
flowchart TD

run["<b>ARC Run</b><br>(Dataset)"]

workflow["<b>ARC Workflow</b><br>(Dataset)"]

runProcess["<b>Workflow Invocation</b><br>(CreateAction, LabProcess)"]

workflowProtocol["<b>Workflow Protocol</b><br>(File, Software, ComputationalWorkflow, LabProtocol)"]

run --mentions--> runProcess
run --about--> runProcess

runProcess --instrument--> workflowProtocol
runProcess --executesLabProtocol--> workflowProtocol
workflow --mainEntity--> workflowProtocol
```

## Requirements

### ARC Workflow

An ARC Workflow is an object that bundles ISA-compliant administrative metadata (e.g., the person that created it) and the prospective provenance of the workflow in form of [Workflow Protocol(s)](#workflow-protocol).
It is based upon [schema.org/Dataset](https://schema.org/Dataset) and maps to the [ISA-XLSX **Workflow**](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#workflow-section).
In the context of an ARC, an ARC Workflow can be seen as the top-level object describing the contents and provenance of a single _workflow folder_ inside the _workflows folder_.

An ARC Workflow contains a `mainEntity` following the [`Workflow Protocol` profile](#workflow-protocol) that describes the _Main Workflow_ of this `workflow folder`, analogous to [Workflow RO Crates](https://about.workflowhub.eu/Workflow-RO-Crate/).

[[ARC_WORKFLOW_REQUIREMENTS]]

### Workflow Protocol

A multitype object that combines [`ComputationalWorkflow`](https://bioschemas.org/types/ComputationalWorkflow/1.0-RELEASE) and [`LabProtocol`](https://bioschemas.org/types/LabProtocol/0.5-DRAFT), providing prospective provenance of computational workflows that can be understood as traditional workflows as well as from a protocol perspective.

[[WORKFLOW_PROTOCOL_REQUIREMENTS]]

### ARC Run

An ARC Run is an object that bundles ISA-compliant administrative metadata (e.g., the person that executed it) and the retrospective provenance of the run in form of [Workflow Invocation(s)](#workflow-invocation).
It is based upon [schema.org/Dataset](https://schema.org/Dataset) and maps to the [ISA-XLSX **Run**](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#run-section).
In the context of an ARC, an ARC Run can be seen as the top-level object describing the contents and provenance of a single _run folder_ inside the _runs folder_.

[[ARC_RUN_REQUIREMENTS]]

### Workflow Invocation

A multitype object that combines [`CreateAction`](https://schema.org/CreateAction) and [`LabProcess`](https://bioschemas.org/types/LabProcess/0.1-DRAFT), providing retrospective provenance of computational workflow execution that can be understood as traditional workflow runs as well as from a process sequence perspective.

[[WORKFLOW_INVOCATION_REQUIREMENTS]]

### FormalParameter

[[FORMAL_PARAMETER_PROFILE_REQUIREMENTS]]

### PropertyValue

[[PROPERTY_VALUE_PROFILE_REQUIREMENTS]]

#### PropertyValue - Workflow Input

A `PropertyValue` that is used as an `object` in a [Workflow Invocation](#workflow-invocation) to describe the realized value for an `input` of a [Workflow Protocol](#workflow-protocol). Distinguishes this `PropertyValue` from process sequence related `object`s by linking it to the realized `input` via the `exampleOfWork` property.

[[WORKFLOW_INPUT_PROFILE_REQUIREMENTS]]

### SoftwareApplication

[[SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS]]

## Compatibility with underlying profiles

## Workflow Run Crate configuration in ARCs

As described above, workflows can be structured hierarchically.
Each workflow (or sub-workflow) object in the hierarchy can have an associated run object in the RO-Crate metadata.
The structure of JSON objects is visualized below.
Every ARC Run consists of one or more Workflow Runs (and is therefore comparable to an [Assay](https://github.com/nfdi4plants/isa-ro-crate-profile/blob/main/profile/isa_ro_crate.md#assay) in ISA).
To reduce complexity, it is recommended to use top level description (marked red).
One workflow describes the transformation of one set of input data to result data.
If a workflow consists of several steps, forwarding the resulting data to the next step without returning them as a final result, it is described as one Workflow Run Crate.
In other words, runs should only be documented for top-level workflows.

```mermaid
flowchart TD
  classDef red fill:#f96,stroke:#333,stroke-width:2px;

  subgraph Workflows
    direction TB
    A["Workflow(ComputationalWorkflow, LabProtocol)"]:::red
    C["Subworkflow/Process A"]
    D["Subworkflow/Process B"]
    E["Subworkflow/Process AA"]
    F["Subworkflow/Process AB"]
    G["Subworkflow/Process AC"]
  end

  subgraph Runs
    direction TB
    B["Run(CreateAction, LabProcess)"]:::red
    H["Run A"]
    I["Run B"]
    J["Run AA"]
    K["Run AB"]
    L["Run AC"]
  end

  A -- "hasPart" --> C
  A -- "hasPart" --> D
  C -- "hasPart" --> E
  C -- "hasPart" --> F
  C -- "hasPart" --> G

  B -- "instrument" --> A
  H -- "instrument" --> C
  I -- "instrument" --> D
  J -- "instrument" --> E
  K -- "instrument" --> F
  L -- "instrument" --> G
```

## Example ro-crate-metadata.json

### Minimal required fields

#### Workflow Profile

```json
[[WP_MINIMAL_JSON]]
```

#### Workflow Run Profile

Note: `exampleOfWork` and `workExample` are not required, but make it easier to understand.

```json
[[WPI_MINIMAL_JSON]]
```

### Minimal required fields with metadata

#### CWL Workflow Profile

```json
[[WP_MINIMAL_METADATA_JSON]]
```

#### Workflow Run Profile

Note: `exampleOfWork` and `workExample` are not required, but make it easier to understand.

```json
[[WPI_MINIMAL_METADATA_JSON]]
```

### Workflow Run RO-Crate compliant example

#### Workflow Profile

```json
[[WP_WRCOMPLIANT_JSON]]
```

#### Workflow Run Profile

Note: `exampleOfWork` and `workExample` are not required, but make it easier to understand.

```json
[[WPI_WRCOMPLIANT_JSON]]
```
