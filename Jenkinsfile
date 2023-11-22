pipeline {
    agent none
    stages {
        stage('Build') {
            agent {dockerfile true}
            steps {
                sh '''
                    cd ./StudentsApp
                    ls -la
                '''
                echo "Building"
            }
        }
    }
}
