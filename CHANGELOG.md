# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2020-06-26
### Changed
- Updated MatchDb to 2.0.0 (Breaking, remove columns and change datatypes to save resources)

## [2.0.1] 2020-06-03
### Changed
- Rename env var AMQP_EXCHANGE_CONSUME_QUEUE to AMQP_INSERTION_INSTRUCTIONS
- Rename env var AMQP_CALLBACK_QUEUE to AMQP_INSERTION_REPLY
### Removed
- Remove env var AMQP_EXCHANGE_NAME

## [2.0.0] 2020-05-27
### Changed
- Replace FanoutConsumer with ordinary Consumer
- Change behaviour on failure: Provide DemoCentral with details and leave it to DemoCentral to decide whether or not to reattempt the analysis
- Redis entries are no longer removed after processing
### Removed
- RansomWare aka. EFCore.Extensions package and replace its usage with raw sql

## [1.1.0] 2020-04-27
### Changed
- Default prefetch count to `1`.
- Added handling of null or empty Match when querying Redis.

## [1.0.4] 2020-04-08
### Changed
- Possibly fixed memory leak by defining scope around IDatabaseHelper, even though it's transient
- Exit application after OutOfMemoryException to facilitate restart

## [1.0.3] 2020-04-03
### Changed
- Bulkinsert PlayerPositions to improve performance and reduce memory usage


## [0.4.8] 2020-03-26
### Added
- Optional Environment variable AMQP_PREFETCH_COUNT

### Changed
- Renamed env var REDIS_URI to REDIS_CONFIGURATION_STRING (same functionality)


## [0.4.0] - 2020-03-04
### Added
- CI

### Changed
- Logging with correct timestamp
- Submodule directories in PascalCase
- Dockerfile
