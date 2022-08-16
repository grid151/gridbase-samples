# Configuring Web Hooks

To get started with receiving web hook calls / notifications from GridBase, begin by signing into gridbase itself starting with the sandbox environment: https://app.sandbox.gridbase.io. Once signed in, click the Developer menu at the top, and click Web Hooks. For each web hook you wish to utilize, you will need to configure it in GridBase like:

<img width="395" alt="gridbase_portal_new-web-hook" src="https://user-images.githubusercontent.com/99702/164792143-d5b421ca-1022-4e60-8326-9a1e091d6479.png">

Once complete, copy the secret key generated, and paste it in place of the asterisks in the corresponding endpoint's sample code, which looks something like: `VerifySignature(input, "********************************************")`.

You will need to then build and publish the project to a server which may be reached by GridBase servers (via HTTPS). Presently direct communication with Grid151 staff will be necessary to trigger the tests from GridBase.
