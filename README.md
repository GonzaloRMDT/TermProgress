# Term Progress

![Example tweet](./docs/img/example.png "Example tweet")

This screenshot shows an example tweet. The bottom numbers display the term's *elapsed days* / *days left* / *total days*.

## What is it?
Term Progress is a Twitter bot written in `C#`/`.NET Core` and inspired by `@year_progress` that periodically creates tweets with information about public officials' terms advance status. It was created originally for `@mandatopresiAR`, to track the argentine presidential term, but it can be extended to any public official tenure.

## What structure has it?
It's designed as a web API that listens to incoming status creation requests, and a worker (Azure Function) responsible for making those requests on a time schedule.

## How can I make my own Term Progress bot?
1. Get a Twitter dev account on [https://developer.twitter.com/](https://developer.twitter.com/).
   
2. Set the following variables on your Term Progress API production environment:
   1. `APPLICATIONCONFIGURATION__ADMINUSERNAME`: your API admin username.
   2. `APPLICATIONCONFIGURATION__ADMINPASSWORD`: your API admin password. 
   3. `TWITTERCLIENTCONFIGURATION__ACCESSTOKEN`: your Twitter access token.
   4. `TWITTERCLIENTCONFIGURATION__ACCESSTOKENSECRET`: your Twitter access token secret.
   5. `TWITTERCLIENTCONFIGURATION__CONSUMERKEY`: your Twitter consumer key.
   6. `TWITTERCLIENTCONFIGURATION__CONSUMERSECRET`: your Twitter consumer secret.
   7. `JSONWEBTOKENCONFIGURATION__AUDIENCE`: a JSON Web Token authentication audience identity.
   8. `JSONWEBTOKENCONFIGURATION__ISSUER`: JSON Web Token authentication issuer identity.
   9. `JSONWEBTOKENCONFIGURATION__SECRETKEY`: JSON Web Token authentication secret key.

3.  On `TermProgress.WebAPI/appsettings.json`, set the following key values:
    1.  `Culture`: Set the desired culture that will be used on tweet generation. By default, it is `es-AR`.
    2.  `StartingDateTime`: set a date and time corresponding to the first day of the term. For example, if the term you would like to track starts on January, 1st, 2021, you should set the value to `2021-01-01T00:00:00`.
    3.  `DurationInYears`: set the number of years that the term should last.
   
4. Set the following variables on your Term Progress worker production environment:
   1. `APPLICATION_ADMIN_USERNAME`: admin username; must be the same as the one you set on your Term Progress API `APPLICATIONCONFIGURATION_ADMINUSERNAME` environment variable.
   2. `APPLICATION_ADMIN_PASSWORD`: admin password; must be the same as the one you set on your Term Progress API `APPLICATIONCONFIGURATION__ADMINPASSWORD` environment variable.
   3. `APPLICATION_AUTHENTICATION_ENDPOINT_URL`: your API authentication endpoint URL. By default, it is `yourdomain.com/api/v1/authentication`.
   4. `TWITTER_STATUS_CREATION_ENDPOINT_URL`: your API Twitter status creation endpoint URL. By default, it is `yourdomain.com/api/v1/termprogress/twitter/createstatus`.

You should set your worker function as a timer triggered every midnight.

## Software license
This software is licensed under the [GNU General Public License v3.0](./LICENSE.md).