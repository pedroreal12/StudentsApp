pipeline {
    agent none
        stages {
            stage ('Run') {
                steps {
                    script {
                        img = docker.build('teste-jenkins').inside('--entrypoint= -e dotnet ./app/StudentsApp.dll') {
                            }   
                    }
                }
            }
        }
}
