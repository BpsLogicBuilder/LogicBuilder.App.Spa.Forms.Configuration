# LogicBuilder.App.Spa.Forms.Configuration

[![CI](https://github.com/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration/actions/workflows/ci.yml/badge.svg)](https://github.com/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration/actions/workflows/ci.yml)
[![CodeQL](https://github.com/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration/actions/workflows/github-code-scanning/codeql)
[![codecov](https://codecov.io/gh/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration/graph/badge.svg?token=WK5MFG350U)](https://codecov.io/gh/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=BpsLogicBuilder_LogicBuilder.App.Spa.Forms.Configuration&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=BpsLogicBuilder_LogicBuilder.App.Spa.Forms.Configuration)

A .NET Standard 2.0 library that provides serializable descriptor classes for defining dynamic form configurations in Single Page Applications (SPAs). This library enables declarative form definitions that specify layout, controls, validation rules, conditional logic, and visibility behavior.

## Overview

`LogicBuilder.App.Spa.Forms.Configuration` contains a comprehensive set of descriptor classes that define form structures and behaviors through configuration rather than code. These descriptors can be serialized to JSON and consumed by SPA frameworks to dynamically render forms with full validation and conditional logic support.

## Key Features

### Form Item Descriptors
The library provides descriptor classes for various form controls and containers:

- **`InputFieldControlSettingsDescriptor`** - Text input fields with templates, validation, and placeholder support
- **`DropdownSelectorControlSettingsDescriptor`** - Dropdown/select controls with custom templates
- **`MultiSelectFormControlSettingsDescriptor`** - Multi-select controls for collections with key field support
- **`FormGroupSettingsDescriptor`** - Nested form groups with field settings and conditional directives
- **`FormGroupArraySettingsDescriptor`** - Array-based form groups for managing collections
- **`FormGroupBoxSettingsDescriptor`** - Container for grouping related form fields

### Control Types
All descriptors inherit from `FormItemSettingDescriptor` and specify their type via the `AbstractControlType` enum:
- `InputFieldControl`
- `DropdownSelectorControl`
- `MultiSelectFormControl`
- `FormGroup`
- `FormGroupArray`
- `GroupBox`

### Validation Configuration
- **`FormValidationSettingDescriptor`** - Defines default values and validators for form controls
- **`ValidatorDescriptionDescriptor`** - Specifies validator functions with configurable arguments
- Support for custom validation messages per field

### Conditional Logic
- **`DirectiveDescriptor`** - Associates directives (show/hide, enable/disable) with condition groups
- **`ConditionGroupDescriptor`** - Logical grouping of conditions with AND/OR operators
- **`ConditionDescriptor`** - Individual conditions comparing variables and values
- **`DirectiveDescriptionDescriptor`** - Defines the directive function to execute when conditions are met

### Templates
- **`TextFieldTemplateDescriptor`** - Custom templates for text input fields
- **`FormGroupTemplateDescriptor`** - Custom templates for form groups
- **`DropDownTemplateDescriptor`** - Custom templates for dropdown controls
- **`MultiSelectTemplateDescriptor`** - Custom templates for multi-select controls

## JSON Serialization

The library includes `FormItemSettingDescriptorConverter`, a custom JSON converter that enables polymorphic serialization and deserialization of form item descriptors using their `TypeString` property. This allows mixed collections of different descriptor types to be serialized and deserialized correctly.

## Use Cases

- Dynamic form generation in Angular, React, Vue, or other SPA frameworks
- Configuration-driven form builders
- Admin interfaces that need runtime form customization
- Multi-tenant applications with per-tenant form configurations
- Forms with complex conditional logic and dynamic validation rules

## Target Framework

- .NET Standard 2.0

## Dependencies

- LogicBuilder.Structures (8.0.2+)

## License

MIT

## Author

BlaiseD / BPS

## Repository

https://github.com/BpsLogicBuilder/LogicBuilder.App.Spa.Forms.Configuration