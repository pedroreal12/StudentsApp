pipeline {
    agent none
        stages {
            steps{
                stage ('Build') {
                    script {
                        docker.build('-f ./Dockerfile .').inside() {
                            sh 'dotnet ./app/StudentsApp.dll'
                        }
                    }
                }
            }
        }
}
