pipeline {
    agent any
    environment {
        registry = "myapp"  // Change this to your preferred image name
        img = "$registry:${env.BUILD_ID}"
        DOCKERFILE_DIR = "CITest/Dockerfile" // Change this to your Dockerfile path
    }
    
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out repository...'
                git branch: 'main', url: 'https://github.com/JasonLee060601/CITest.git'
                sh 'ls -la'
            }
        }
        stage('Build Application') {
            steps {
                echo 'Building application...'
                sh 'dotnetBuild --configuration Release'
            }
        }
        stage('Create Docker Image') {
            steps {
                echo 'Building Docker image...'
                sh "docker build -t ${img} ${DOCKERFILE_DIR}"
            }
        }
        stage('Run Docker Container') {
            steps {
                echo 'Running container...'
                sh "docker run --rm -d --name ${JOB_NAME} -p 8081:5000 ${img}"
            }
        }
        stage('Verify Docker Image') {
            steps {
                echo 'Listing available Docker images...'
                sh "docker images | grep ${registry}"
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
