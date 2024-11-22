pipeline {
    agent {
	    label 'WindowsJenkinsAgent'
    }

    stages {
	    stage('Checkout')
	    {
        	steps
	    	{
				cleanWs()
				
				checkout scm
  		    }
	    }
    }
}
