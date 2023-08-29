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
| stateAbbreviation | Two character state abbreviation   | string    |
| countyFips        | Fips code for the county           | string    |
| documentTypes     | Document Types Refinance, Mortgage | string    |
| integrationId     | Clients unique integration Id      | string    |

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
| Property.Street          | Property Address                                                                                                                  | string    |
| Property.CityDesc        | Property City                                                                                                                     | string    |
| Property.StateId         | Property State                                                                                                                    | string    |
| Property.CountyDesc      | Property County                                                                                                                   | string    |
| Property.Zip             | Property Zip Code                                                                                                                 | string    |
| TransacitionType         | Transaction Type (Purchase, Refinance, Modification)                                                                              | string    |
| DocumentType             | Fee Document Type (None, Amendment, Assignment, Deed, Modification, Mortgage, PowerOfAttorney, Refinance, Release, Subordination) | string    |
| TitleAgent.FinancingType | Finance Type (Sale, Refinance)                                                                                                    | string    |
| TitleAgent.PolicyType    | Policy Type (New, Reissue)                                                                                                        | string    |

### Request Body Example

```json
{
  "IntegrationId": "12345",
  "EstimatedClosingDate": "2023-08-10T15:30:00Z",
  "DocumentTypes": ["Mortgage"],
  "InspectionService": {
    "Address": "123 Main St",
    "City": "Sample City",
    "Zip": "12345",
    "SquareFootage": 2000,
    "YearBuilt": 2000,
    "LotSize": 0.25,
    "IsInspection": true,
    "InspectionTypes": [
      { "Key": "Mold", "Name": "Mold Inspection", "Value": true },
      { "Key": "Asbestos", "Name": "Asbestos Inspection", "Value": false }
    ],
    "NumberOfSamples": {
      "MoldAirSamples": 2,
      "MoldSurfaceSamples": 3,
      "AsbestosSamples": 0,
      "LeadPaintSamples": 1,
      "DrywallSamples": 0
    }
  },
  "Mortgage": {
    "Pages": 15,
    "NewDebtAmount": 250000,
    "OriginalAmount": 300000,
    "UnpaidBalance": 200000
  },
  "Property": {
    "StreetAddress": "456 Elm St",
    "City": "Sample City",
    "State": "CA",
    "Zip": "54321"
  },
  "Customizations": {
    "Assignment": { "Pages": 2, "Amount": 100 },
    "Deed": { "Pages": 3, "Amount": 150 },
    "Release": { "Pages": 1, "Amount": 75 },
    "Subordination": { "Pages": null, "Amount": 200 },
    "PowerOfAttorney": { "Pages": null, "Amount": 50 }
  },
  "Questions": [
    { "Id": "Q1", "Answer": "Yes", "QuestionType": "Bool" },
    { "Id": "Q2", "Answer": "12345", "QuestionType": "Number" }
  ],
  "TitleAgent": {
    "TitleVendor": "Sample Title Company",
    "City": "Sample City",
    "FinancingType": "Sale",
    "PolicyType": "New",
    "UseSimultaneousRates": true,
    "LoanAmount": 200000,
    "PurchaseAmount": 300000
  },
  "TransactionType": "Purchase",
  "UseItemizedSettlementFees": true,
  "Endorsements": ["Endorsement1", "Endorsement2"]
}
```
