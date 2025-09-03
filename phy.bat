
cd c:\rahul\dev\phy
set PATH=%PATH%;C:\Users\rahuls\AppData\Roaming\Python\Python39\Scripts;
pip install --upgrade pip
rem conda install -c conda-forge jupyterlab
rem conda install -c conda-forge notebook
rem conda install -c conda-forge voila
rem md stock-pred
cd stock-pred
conda config --set ssl_verify False
jupyter notebook --version
pip install --trusted-host pypi.org --trusted-host files.pythonhosted.org pandas
pip install matplotlib-venn
pip install numpy
pip install pandas
pip install -U scikit-learn
pip install keras.models 
pip install keras.layers
pip install matplotlib
pip install pandas_datareader

jupyter notebook

jupyter lab