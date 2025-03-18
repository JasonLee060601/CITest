pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                echo 'now checking out'
                checkout scm
            }
        }
        stage('Build') {
            steps {
                echo 'now building'
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
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
