# MatchWriter
Inserts and manages MatchDataSets in MatchDb.

## Environment Variables
- `MYSQL_CONNECTION_STRING` : Connection string for Match Database. [*]
- `AMQP_URI` : URI to the rabbit cluster [*]
- `REDIS_CONFIGURATION_STRING` : URI to redis cache. Specifying `REDIS_CONFIGURATION_STRING="mock"` resolves to a mocked instance. [*]
- `AMQP_CALLBACK_QUEUE` : Rabbit queue's name for producing messages to DemoCentral [*]
- `AMQP_DEMOCENTRAL_DEMO_REMOVAL` : Rabbit queue's name for receiving demo removal instruction from DemoCentral[*]
- `AMQP_DEMOCENTRAL_DEMO_REMOVAL_REPLY` : Rabbit queue's name for reporting back about demo removal to DemoCentral[*]
- `AMQP_EXCHANGE_NAME` : Rabbits exchange name for finding Fanout [*]
- `AMQP_EXCHANGE_CONSUME_QUEUE` : Rabbit queue's name for consuming messages from Fanout 
- `AMQP_PREFETCH_COUNT` : Prefetch limit for rabbit, defaults to 0
- `IS_MIGRATING` : Boolean to indicate if migration is active

[*] *Required*

## Managing Matches
Use the endpoints  
 - `GET: /api/match/<matchId>`
 To get metadata about a match in the MatchDb.

- `GET: /api/match/<matchId>`
To remove all data of this match from MatchDb.