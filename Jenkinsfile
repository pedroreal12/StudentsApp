pipeline {
    agent none
    stages {
        stage('Build') {
            agent {dockerfile true args '--entrypoint'}
            steps {
                sh '''
                    pwd
                    cd ./StudentsApp
                    cd ./StudentsApp
                    ls -la
                '''
                echo "Building"
            }
        }
    }
}
