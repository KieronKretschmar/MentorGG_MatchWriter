# MatchWriter
Inserts and manages MatchDataSets in MatchDb.

## Environment Variables
- `MYSQL_CONNECTION_STRING` : Connection string for Match Database. [*]
- `AMQP_URI` : URI to the rabbit cluster [*]
- `REDIS_URI` : URI to redis cache. Specifying `REDIS_URI="mock"` resolves to a mocked instance. [*]
- `AMQP_CALLBACK_QUEUE` : Rabbit queue's name for producing messages to DemoCentral [*]
- `AMQP_EXCHANGE_NAME` : Rabbits exchange name for finding Fanout [*]
- `AMQP_EXCHANGE_CONSUME_QUEUE` : Rabbit queue's name for consuming messages from Fanout 
- `AMQP_PREFETCH_LIMIT` : Prefetch limit for rabbit, defaults to 0
- `IS_MIGRATING` : Boolean to indicate if migration is active

[*] *Required*
