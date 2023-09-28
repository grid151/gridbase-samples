# GridBase Instant Decision Reports

GridBase Instant Decision Reports (powered by X1 Analytics) allows lenders to close more quickly and determine the title condition (including "Clear to Close").

# API Guide

Before you begin, make sure you already have a GridBase sandbox account for development and testing purposes. You'll need to log in and acquire your access token as [described in the introduction](https://github.com/grid151/gridbase-samples#authentication-with-the-gridbase-api).

## Step 1: Stage and Place an Order

To stage a new order, submit an HTTP POST request to `/v1/orders/stage` using the [example request](01_stage.json). This will return a 201 (created) response with the order object you submitted, with the order ID in the `id` property. Fields include:

| Field Name                       | Field Description                     | Required |
|----------------------------------|---------------------------------------|----------|
| `IntegrationId`                  | Integration ID         | &check;  |
| `orderDetails.clientFileNumber`  | The client's file number (must be unique)      | &check;  |
| `orderDetails.newLoanAmount`     | The loan amount                   | &check;  |
| `orderDetails.newLoanNumber`     | A unique identifier for the new loan  | &check;  |
| `orderDetails.cashoutAmount`     | Cashout Amount                        | &check;  |
| `orderDetails.transactionTypeDesc`| Description of the type of transaction| &check;  |
| `parties.buyers[].buyerSellerTypeID` | Type ID for buyer or seller         | &check;  |
| `parties.buyers[].firstName`     | Buyer's First Name                    | &check;  |
| `parties.buyers[].lastName`      | Buyer's Last Name                     | &check;  |
| `parties.buyers[].address.street`| Street Address of Buyer               | &check;  |
| `parties.buyers[].address.cityDesc`| City of Buyer                        | &check;  |
| `parties.buyers[].address.stateId`| State of Buyer                       | &check;  |
| `parties.buyers[].address.zip`   | Zip code of Buyer                     | &check;  |
| `parties.lender.lenderId`        | ID for the lender                     |   |
| `parties.lender.companyName`     | Lender Company Name                   |   |
| `property.address.street`        | Property Address 1                    | &check;  |
| `property.address.cityDesc`      | Property City/Locality Description    | &check;  |
| `property.address.stateId`       | Property State                        | &check;  |
| `property.address.zip`           | Property Zip/Postal Code              | &check;  |
| `property.propertyType`          | Type of Property                      | &check;  |
| `system`                         | System being used (e.g., X1)          | &check;  |
| `product`                        | Type of product (e.g., order)         | &check;  |



Once the order is staged, you may then submit a PUT request to `/v1/orders/place/{id}` (where `{id}` is replaced with the order ID returned from the previous request). Note that order placement may take some time to complete

### Product Types:

| Product Type | Description                    |
| ------------------- | ------------------------------ |
| decision-report    | For submitting a decision report           |
| decision-report-resubmit    | For resubmitting a decision report       |
| decision-report-update      | For updating a decision report     |

Transaction Types Supported:
| Transaction Type | Description |
| --- | --- |
| 'EquityNC' | Equity - **N**o **C**redit pull |
| 'EquityLV' | Equity - **L**egal and **V**esting |
| 'Refinance' | Refinance |
| 'Equity' | Equity |
| 'EquityPR' | Equity - Property Report |

### Buyer/Borrower Type Values:

| Buyer/Borrower Type | Description                    |
| ------------------- | ------------------------------ |
| Individual          | An individual person           |
| Corporation         | A corporate entity             |
| Partnership         | A business partnership         |
| LLC                 | Limited Liability Company      |

### Property Type Values:

| Property Type          | Description                      |
| ---------------------- | -------------------------------- |
| Single Family          | Single-family home               |
| SFR                    | Single-family residence          |
| PUD                    | Planned Unit Development         |
| Condominium            | Condominium                      |
| Condo                  | Condominium (short form)         |
| 2-4 Plex               | Property with 2-4 units          |
| Cooperative            | Co-op housing                    |
| Unimproved             | Unimproved land                  |
| Vacant Land            | Empty land                       |
| Multiple Family Residence | Property with multiple families |
| Commercial             | Commercial property              |
| Property               | Generic property type            |

## Step 2: Retrieve the Report

Once order placement has completed, you may submit a `POST` request to `/v1/core/reports/generate` with the following request body to generate a report:

```json
{
    "orderId": "{id}",
    "reportId": "6324d73af55f885d0d71b6a4",
    "reportFormat": "pdf"
}
```

### Report Ids

Different types of reports may be generated by passing the corresponding `ReportId` value, including:
- `6324d73af55f885d0d71b6a4` - Lender Decision Report
- `6324d851f55f885d0d71b6a9` - Title Decision Report

### Report Formats

Supported formats include `pdf` and `xml`.

- `xml` - provides raw report data as an XML document, which may be used to implement process automation. 
- `pdf` - provides a pre-formatted, print-friendly PDF document.


## Step 3 (optional): Order Updates or Corrections

To update an existing order, submit an HTTP POST request to `/v1/orders/update` using the [example request](03_update.json) where the main difference between the stage is the ID field is populated. This will return a 200 (successful) response with the order object you submitted.

Once the order has been updated, you may then submit a PUT request to `/v1/orders/place/{id}` (where `{id}` is the order ID). Note that order placement may take some time to complete

Finally step 2 can be repeated for an updated report.
