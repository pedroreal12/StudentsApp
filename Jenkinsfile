pipeline {
    agent {dockerfile true}
        stages {
            stage ('Run') {
                steps {
                    sh '''
                        cd ./app/
                        dotnet ./StudentsApp.dll
                    '''
                }
            }
        }
}
