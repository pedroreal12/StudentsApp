pipeline {
    agent none
        stages {
            stage('Building DB') {
                agent {
                    dockerfile {
                        filename 'Dockerfile.db'
                            dir './'
                    }
                }
                steps {
                    sh '''
                        echo "Building DB"
                        '''
                }
            }
            stage('Building Server') {
                agent {
                    dockerfile {
                        filename 'Dockerfile'
                            dir './'
                    }
                }
                steps {
                    sh '''
                        echo "Building Server"
                        cd ./StudentsApp/app
                        dotnet StudentsApp.dll
                        '''
                } 
            }
        }
}
