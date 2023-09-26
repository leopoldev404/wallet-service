echo "Starting Cleanup..."
docker-compose -f docker/docker-compose.yml down
docker volume rm docker_postgres_data
docker volume rm docker_mongodb_data
echo "Clean Completed! 💩"