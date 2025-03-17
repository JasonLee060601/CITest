pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building...'
                bat 'dotnet restore'
                bat 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                echo 'Running unit tests...'
                bat 'dotnet test YourTestProject/YourTestProject.csproj'
                
                // To publish test results:
                // junit '**/test-results/*.xml'
            }
        }
    }
    post {
        always {
            echo 'Pipeline completed'
            // You can add steps to always run after the pipeline, such as:
            // cleanWs() // Clean workspace
        }
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
