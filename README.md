# MatchWriter
Inserts and manages MatchDataSets in MatchDb.

## Environment Variables
- `MYSQL_CONNECTION_STRING` : Connection string for Match Database. [\*]
- `AMQP_URI` : URI to the rabbit cluster [\*]
- `REDIS_CONFIGURATION_STRING` : URI to redis cache. Specifying `REDIS_CONFIGURATION_STRING="mock"` resolves to a mocked instance. [\*]
- `AMQP_DEMOCENTRAL_DEMO_REMOVAL` : Rabbit queue's name for receiving demo removal instruction from DemoCentral[\*]
- `AMQP_DEMOCENTRAL_DEMO_REMOVAL_REPLY` : Rabbit queue's name for reporting back about demo removal to DemoCentral[\*]
- `AMQP_INSERTION_INSTRUCTIONS` : Rabbit queue's name for consuming insertion instruction from DemoCentral 
- `AMQP_INSERTION_REPLY` : Rabbit queue's name for producing insertion reports to DemoCentral [\*]
- `AMQP_PREFETCH_COUNT` : Prefetch limit for rabbit, defaults to `1`
- `IS_MIGRATING` : Boolean to indicate if migration is active

[\*] *Required*

## Managing Matches
Use the endpoints  
 - `GET: /api/match/<matchId>`
  Get **metadata** about a match in the MatchDb.
- `PUT: /api/match/<matchId>`
  Replace a match in MatchDb.
- `DELETE: /api/match/<matchId>`
  Delete a match from MatchDb.
