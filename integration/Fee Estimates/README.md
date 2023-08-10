# Fee Estimate Integration

This README file describes several API endpoints for interagrating with Fee Estimates, a tool for getting an estimation for specific properties based on a specific set of requirements. The file provides detailed information on the required fields for each endpoint.

## Table of Contents

All of the following endpoints are GET request except for the "Request Quote" endpoint which is a POST request. All of the GET request can be used as helpers in order to properly fill out you request for a quote.

- [Get Fee Standards](#get-fee-standards)
- [Get Questions](#get-questions)
- [Request Quote](#request-quote)

## Get Fee Standards

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

## Request Quote

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
  "IntegrationId": "123456",
  "EstimatedClosingDate": "2023-08-10T15:30:00Z",
  "DocumentType": "Mortgage",
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
    { "Id": "Q1", "Answer": "Yes", "QuestionType": "Boolean" },
    { "Id": "Q2", "Answer": "12345", "QuestionType": "Number" },
    { "Id": "Q3", "Answer": "Sample answer", "QuestionType": "Text" }
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
