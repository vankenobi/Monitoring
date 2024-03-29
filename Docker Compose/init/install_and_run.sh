#!/bin/bash

# Cron Job
CRON_COMMAND="*/1 * * * * ab -n 200 -c 20 http://host.docker.internal:8081/WeatherForecast >> /var/log/ab.log 2>&1"

apt-get update -y
apt-get install apt-utils dialog libterm-readline-gnu-perl apache2-utils vim cron -y
echo -e "\e[32mDependencies installed!\e[0m"

service cron start
echo -e "\e[32mCron service started!\e[0m"

echo "$CRON_COMMAND" | crontab -

echo service cron reload
echo -e "\e[32mCron service reloaded!\e[0m"

echo -e "\e[32mCron job added successfully!\e[0m"

tail -f /dev/null

