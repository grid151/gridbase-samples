# Integration Guide for GridBase Fee Estimates

This document outlines various API endpoints designed for seamless integration with GridBase Fee Estimates, a powerful tool that offers estimation based on a property and user-provided requirements. Below, you'll find comprehensive insights into the essential fields associated with each individual endpoint. Feel free to refer to this guide as you embark on integrating Fee Estimates into your system. It will ensure a smooth and successful integration process.

## Table of Contents

All of the following endpoints are HTTP `GET` requests except for the "Request Quote" endpoint which is an HTTP `POST` request. All of the `GET` requests can be used as helpers in order to properly fill out you request for an estimate.

- [Get Fee Standards](#get-fee-standards)
- [Get Questions](#get-questions)
- [Request Estimate](#request-estimate)

## Get Fee Standards

`GET /v1/orders/fees/fee-standards/{feeType}/{state}/{integrationId}`

#### Example

`GET /v1/orders/fees/fee-standards/Endorsement/FL/kljsldfjdljfldkjfl`

### Response Body Example

```json
[
  {
    "code": "2000010",
    "name": "ALTA 18.3-06 - Single Tax Parcel and ID",
    "category": "OTHER"
  },
  {
    "code": "2000011",
    "name": "Mortgage Survey Affidavit",
    "category": "SURVEY"
  },
  {
    "code": "0000001",
    "name": "Title - ALTA 1 Street Assessments",
    "category": "OTHER"
  },
  {
    "code": "0000029",
    "name": "Title - ALTA 10 Assignment",
    "category": "OTHER"
  }
]
```

## Get Questions

`POST /v1/orders/fees/questions`

### Required Fields

| Field Name        | Field Description                  | Data Type |
| ----------------- | ---------------------------------- | --------- |
| `stateAbbreviation` | Two character state abbreviation   | string    |
| `countyFips`        | Fips code for the county           | string    |
| `documentTypes`     | Document Types Refinance, Mortgage | string    |
| `integrationId`     | Clients unique integration Id      | string    |

### Request Body Example

```json
{
  "stateAbbreviation": "PA",
  "countyFips": "42007",
  "documentTypes": ["Refinance"],
  "integrationId": "12345"
}
```

### Response Body Example

```json
[
  {
    "id": "Q15",
    "description": "Is this a reverse mortgage?",
    "answer": "false",
    "questionType": "Bool"
  },
  {
    "id": "Q50",
    "description": "Is this transaction being recorded electronically?",
    "answer": "false",
    "questionType": "Bool"
  }
]
```

## Request Estimate

`POST /v1/orders/fees/quote`

### Required Fields

| Field Name               | Field Description                                                                                                                 | Data Type |
| ------------------------ | --------------------------------------------------------------------------------------------------------------------------------- | --------- |
| `property.street`          | Property Address                                                                                                                  | string    |
| `property.cityDesc`        | Property City                                                                                                                     | string    |
| `property.stateId`         | Property State                                                                                                                    | string    |
| `property.countyDesc`      | Property County                                                                                                                   | string    |
| `property.zip`             | Property Zip Code                                                                                                                 | string    |
| `transacitionType`         | Transaction Type (Purchase, Refinance, Modification)                                                                              | string    |
| `documentType`             | Fee Document Type (None, Amendment, Assignment, Deed, Modification, Mortgage, PowerOfAttorney, Refinance, Release, Subordination) | string    |
| `titleAgent.financingType` | Finance Type (Sale, Refinance)                                                                                                    | string    |
| `titleAgent.policyType`    | Policy Type (New, Reissue)                                                                                                        | string    |

### Request Body Example

```json
{
  "integrationId": "12345",
  "estimatedClosingDate": "2023-08-10T15:30:00Z",
  "documentTypes": ["Mortgage"],
  "inspectionService": {
    "address": "123 Main St",
    "city": "Sample City",
    "zip": "12345",
    "squareFootage": 2000,
    "yearBuilt": 2000,
    "lotSize": 0.25,
    "isInspection": true,
    "inspectionTypes": [
      { "key": "Mold", "name": "Mold Inspection", "value": true },
      { "key": "Asbestos", "name": "Asbestos Inspection", "value": false }
    ],
    "numberOfSamples": {
      "moldAirSamples": 2,
      "moldSurfaceSamples": 3,
      "asbestosSamples": 0,
      "leadPaintSamples": 1,
      "drywallSamples": 0
    }
  },
  "mortgage": {
    "pages": 15,
    "newDebtAmount": 250000,
    "originalAmount": 300000,
    "unpaidBalance": 200000
  },
  "property": {
    "streetAddress": "456 Elm St",
    "city": "Sample City",
    "state": "CA",
    "zip": "54321"
  },
  "customizations": {
    "assignment": { "Pages": 2, "Amount": 100 },
    "deed": { "Pages": 3, "Amount": 150 },
    "release": { "Pages": 1, "Amount": 75 },
    "subordination": { "Pages": null, "Amount": 200 },
    "powerOfAttorney": { "Pages": null, "Amount": 50 }
  },
  "questions": [
    { "id": "Q1", "answer": "Yes", "questionType": "Bool" },
    { "id": "Q2", "answer": "12345", "questionType": "Number" }
  ],
  "titleAgent": {
    "titleVendor": "Sample Title Company",
    "city": "Sample City",
    "financingType": "Sale",
    "policyType": "New",
    "useSimultaneousRates": true,
    "loanAmount": 200000,
    "purchaseAmount": 300000
  },
  "transactionType": "Purchase",
  "useItemizedSettlementFees": true,
  "endorsements": ["Endorsement1", "Endorsement2"]
}
```
