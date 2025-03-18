pipeline {
    agent {
        docker { image 'docker' }
    }
    environment{
        registry = "CITest/main"
        img = "$registry" + ":${env.BUILD_ID}"
        DOCKERFILE_DIR = "path/to/dockerfile/directory"
    }
    
    stages {
        stage('Checkout') {
            steps {
                echo 'now checking out'
                git branch: 'main', url: 'https://github.com/JasonLee060601/CITest.git'
                sh 'ls -la'
            }
        }
        stage('Stop running Container') {
            steps {
                sh returnStatus: true, script: 'docker stop $(docker ps -a | grep ${J0B_NAME} | awk \'{print $1}\')'
                sh returnStatus: true, script: 'docker rmi $(docker images | grep ${registry} | awk \'{print $3}\') -- force'
                sh returnStatus: true, script: 'docker rm ${JOB_NAME}'
            }
        }
        stage('Build') {
            steps {
                echo 'now building'
                script{
                    dockerImg = docker.build("${img}", "${DOCKERFILE_DIR}")
                }
            }
        }
        stage('Run') {
            steps {
                echo 'Run Image'
                sh returnStdout: true, script: "docker run -- rm -d -- name ${JOB_NAME} -p 8081:5000 ${img}"
            }
        }
        stage('Test') {
            steps {
                echo 'now conduct testing'
                sh 'dotnet test WeatherForecast.API.Test/WeatherForecast.API.Test.csproj'
            }
        }
        stage('Publish') {
            steps {
                echo 'now publishing'
                sh 'dotnet publish --configuration Release'
            }
        }
    }
    post {
        always {
            echo 'Pipeline completed'
        }
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
