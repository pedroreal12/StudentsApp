pipeline {
        stages {
            stage ('Run') {
                steps {
                    agent {dockerfile true}
                    sh '''
                        ls -al
                        cd ./app/
                        dotnet ./StudentsApp.dll
                    '''
                }
            }
        }
}
