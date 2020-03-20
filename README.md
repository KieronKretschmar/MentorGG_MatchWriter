# MatchWriter
Inserts and manages MatchDataSets in MatchDb.

## Environment Variables
- `MYSQL_CONNECTION_STRING` : Connection string for Match Database. [*]
- `AMQP_URI` : URI to the rabbit cluster [*]
- `REDIS_URI` : URI to redis - mockable "mock"
- `AMQP_DEMOFILEWORKER_QUEUE` : Rabbit queue's name for consuming messages from DemoFileWorker [*]
- `AMQP_CALLBACK_QUEUE` : Rabbit queue's name for producing messages to DemoCentral [*]
- `AMQP_EXCHANGE_NAME` : Rabbits exchange name for reading from Fanout [*]
- `IS_MIGRATING` : Boolean to indicate if migration is active

[*] *Required*
