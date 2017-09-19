# Aggregation Framework C# console sample

This repository demonstrates the use of the [MongoDB .NET driver](https://docs.mongodb.com/ecosystem/drivers/csharp/) for aggregation framework queries. It is a port of [Jay Runkel's Aggregation Framework repository](https://github.com/jayrunkel/mongoDBAggWebFeb2015) from the MongoDB Shell over to the MongoDB C# driver.

## Setup instructions

To use this repository, open a command line in the root of the repository and run a [mongorestore](https://docs.mongodb.com/manual/reference/program/mongorestore) command (with the appropriate parameters if you don't use a local installation of MongoDB) to restore the US Census dataset used by this code sample.