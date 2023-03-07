# SoftPro Integration

This README file describes several API endpoints for integrating with SoftPro, a real estate and title insurance software company. The file provides detailed information on the required fields for each endpoint.

## Table of Contents

- [Place Order](#place-order)
- [Update Order](#update-order)
- [Add Document](#add-document)
- [Add Note](#add-note)
- [Cancel Order](#cancel-order)


## Place Order

### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| orderDetails.ProductTypeDesc | Products Available to order | string |
| orderDetails.transactionTypeDesc | Transaction Type | string |
| Loan Type | Per SoftPro, they will add a Description field if 'Other' selected for Loan Type | string |
| parties.buyers.lastName | Buyers Last Name | string |
| parties.buyers.firstName | Buyers First Name | string |
| parties.lender.companyName | Lender Company Name | string |
| property.address.street | Property Address 1 | string |
| property.address.cityDesc | Property City Description | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |

Required (Yes/No) Additional description if requirement is conditional.

### Request body example

Here is a an [example request body](sample/order.json)


## Update Order

### Required fields

> Updates will take the full order, anything left null should not replace an existing value.  (**Will confirm with SoftPro**)


| Field Name | Field Description | Data Type |
|---|---|---|
| orderDetails.ProductTypeDesc | Products Available to order | string |
| orderDetails.transactionTypeDesc | Transaction Type | string |
| Loan Type | Per SoftPro, they will add a Description field if 'Other' selected for Loan Type | string |
| parties.buyers.lastName | Buyers Last Name | string |
| parties.buyers.firstName | Buyers First Name | string |
| parties.lender.companyName | Lender Company Name | string |
| property.address.street | Property Address 1 | string |
| property.address.cityDesc | Property City Description | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |


Here is a an [example request body](sample/order.json)


## Add Document

### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| fileName | Name of file without extension | string |
| documentBody | Document as a Base64 string | string |
| extension | extenstion of the uploaded file txt, pdf, etc | string |

Here is a an [document upload request body](sample/document.json)

## Add Note

### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| noteSubject | Note Subject | string |
| noteBody | Note Body | string |

### Request body example

```json
{
  "noteSubject": "<string>",
  "noteBody": "<string>",
  "description": "<string>"
}
```

## Cancel Order

### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| orderId | unique identifier of the order | string |
| cancelReason | Reason for cancelling order | string |

### Request body example

```json
{
    "orderId": "63f---------------443413",
    "cancelReason": "Test Cancel"
}
```
