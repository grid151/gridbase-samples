# Interacting with Orders

In GridBase, an order is vaguely a request to have a supported system fulfill some action (or product/service the system offers) fulfilled. This guide provides walks through interacting with an order pushed to a Title Production System (TPS) - Resware in this example.

## Step 1: Get Type Mappings

Submit an HTTP GET request to the `/v1/orders/typemappings/read/Resware` to retrieve type mappings. This will provide you with the possible values you can use for properties like `orderDetails.productTypeId` and `orderDetails.transactionTypeId` when staging the order.

## Step 2: Stage an Order

GridBase requires you to stage an order before submitting it for placement with the target system (Resware in this example). To begin, submit an HTTP POST request to `/v1/orders/stage` using the [example request](01_stage.json). Once complete, you may optionally update the order object by submitting HTTP PUT requests to `/v1/orders/update`.

## Step 3: Place the Order

To request order placement, begin by submitting PUT request to `/v1/orders/place/{orderId}`. This step will first validate the order staged to ensure it is ready to be submitted to the system. Assuming validation passes, Gridbase will then queue the order for placement and return success. To receive the result of order placement, you will need to either view the order in the GridBase Portal and verify its status is submitted. Alternatively, you can configure a [Web Hook](https://github.com/grid151/gridbase-samples/tree/main/csharp/webhooks) to notify your system when an order was placed successfully or failed to be placed.

## Step 4: Additional Interactions

Once the order is placed, you can begin with some basic interactions, including:

### Reading an Order

Your system will be able to read the order and its most recent contents by submitting an HTTP GET request to `/v1/orders/read/{orderId}`.

### Adding a Note

New notes can be submitted to the order in the target system by submitting an HTTP PUT request to `/v1/notes/add/{orderId}` with a request body like:
```json
{
    "noteBody" : "I'm a hurricane survivor",
    "noteSubject" : "I'm a survivor"
}
```

### Adding a Document

New documents can be submitted to the order in the target system by submitting an HTTP POST request to `/v1/documents/create/{orderId}` with a request body like:
```json
{
    "NoteSubject": "Test document 2022-11-04",
    "NoteBody": "This is a test document",
    "Documents": [
        {
            "FileName": "testdoc.pdf",
            "DocumentTypeID": "1025",
            "DocumentBody": "Place your base-64 encoded document string here",
            "Extension": "pdf",
            "DocumentName": "Hi! I'm a document name.",
            "Description": "Hi! I'm a document"
        }] 
}
```

A full [example request](05_document.json) with a base-64 encoded document file is available.

### Notifications to your System

[Web Hooks](https://github.com/grid151/gridbase-samples/tree/main/csharp/webhooks) can be configured to send notifications to your system when events occur on the order in the target system. This can include things like new orders being created, new notes or documents added to the order, or actions taken or completed on the order.
