pipeline {
    agent any
    environment {
        // Define environment variables if needed
        MSBUILD_PATH = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\BuildTools\\MSBuild\\Current\\Bin\\MSBuild.exe'
    }
    stages {
        stage('Checkout') {
            steps {
                // Check out the source code from version control
                echo 'now checking out'
                checkout scm
            }
        }
        stage('Build') {
            steps {
                // Build the .NET project
                echo 'now building'
                bat "\"${MSBUILD_PATH}\" /t:Restore,Build /p:Configuration=Release"
            }
        }

        stage('Test') {
            steps {
                // Run tests (replace with your test command)
                echo 'now conduct testing'
                bat 'dotnet test WeatherForecast.API.Test/WeatherForecast.API.Test.csproj'
            }
        }

        stage('Publish') {
            steps {
                // Publish the .NET application
                echo 'now publishing'
                bat "\"${MSBUILD_PATH}\" /t:Publish /p:Configuration=Release"
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
