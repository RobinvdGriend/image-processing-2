# assignment 2

Use the provided framework and add the following functionality:

- [ ] **Structuring element**: implement a function that takes as input the structure element shape (+ or rectangle) and size and outputs the corresponding structure element. (5 points)

- [ ] **Erosion/dilation**: implement two functions that take a grayscale image and a structuring element as input and output the eroded/dilated image, respectively. Your functions should also work for binary images. Perform all necessary checks. (10 points)
- [ ] **Opening/closing**: implement two functions that take a grayscale image and a structuring element as input and output the image after morphological opening and closing, respectively. Your functions should also work for binary images. Perform all necessary checks. (5 points)
- [ ] **Complement**: implement a function that takes a grayscale image as input and outputs the complement of the image. For binary images, white should become black and vice versa. (5 points)
- [ ] **AND/OR**: implement two functions that take two binary images as input and output the pixel-wise AND and OR of both images, respectively. Check the input arguments. (5 points)
- [ ] **Value counting**: implement a function that takes a grayscale image as input and outputs (1) the number of distinct values and (2) a histogram how often each value occurs. (10 points
- [ ] **Boundary trace**: implement a function that, given a binary image, traces the outer boundary of a foreground shape in that image. The output of the function is a list (choose your implementation) of (x,y)-pairs, each corresponding to a boundary pixel. Subsequent pairs in the list should be neighboring pixels in the image. The material for this function will be discussed later, but have a look at Book II - Chapter 2 and the code in Book II - B.1.4. You may assume there is only a single shape in the image, or return only the list of the first boundary that you encounter. (10 points).

Choose what happens with boundary pixels. Make sure your code works with structuring elements of arbitrary size. Have the proper checks for (matching) image sizes and values being within the expected range. Demonstrate your implementation by loading image B from Assignment 1. Make sure it is a binary single channel image. We call this image W. Then:

1. dilate image W with a 3x3 square kernel. This is image X.
2. erode image W with a 3x3 square kernel. This is image Y.
3. take the AND of image X and the complement of Y. This is image Z.
4. use image A from Assignment 1, convert it to grayscale and perform a series of dilations with increasing structuring element size. Choose the shape of the element (e.g. plus, square), but keep it fixed. The resulting images are E1...En.
5. for each image E1...En, count the number of distinct values F1..Fn.
6. use [this image](https://uu.blackboard.com/bbcswebdav/pid-3292336-dt-content-rid-29187500_2/xid-29187500_2) . Perform a series of openings with increasing structuring element size (take steps of 20, i.e., 3x3, 23x23, 43x43, etc.). Choose the shape of the element (e.g. plus, square), but keep it fixed. The resulting images are G1...Gn.
7. for each image G1...Gn, count the number of non-background values H1..Hn.

Write a brief (2-page) report with:

- [ ] the images X, Y and Z. Explain what result Z is. (10 points)
- [ ] a graph with on the x-axis the size of the structuring element and on the y-axis the values F1...Fn. Explain what you see. How can this be explained? (5 points)
- [ ] the images G1...Gn and a graph with on the x-axis the size of the structuring element and on the y-axis the values H1...Hn. Explain what you see. How can this be explained? (10 points) 

**Submission**: Submit through Blackboard (Image Processing Assignment 2) an archive with:

1. your code (**no** binaries/libs)
2. your 2-page report

Mark all deliverables clearly with your names and student numbers. Make sure your code runs out-of-the-box. Handing in code with a batch or command file that starts a compilation is completely at your own risk. Make sure your file size is smaller than 30MB. **Don't** submit your assignment by email.

**Grading**: your grade is the number of points divided by 10. If you correctly implement the mentioned functionality and provide all requested information in your report, your maximum grade is 8. You can earn a maximum of 20 bonus points by:

1. adapting the dilation/erosion functions to take an optional additional input for the control image. If this input is provided, the functions should operate as a geodesic dilation/erosion. Your function should work with binary and grayscale images. If it only works for binary images, the maximum score is 5 points. Make sure you check the input arguments. (10 points)
2. show how you could remove noise (i.e., high-frequency patterns) using morphologic operations. Explain your rationale in your report. (10 points)
3. implement a function that takes a binary image such as [this one](https://uu.blackboard.com/bbcswebdav/pid-3292336-dt-content-rid-29187500_2/xid-29187500_2)  and returns the same image but with only the largest shape on it, so with all other shapes removed. (10 points)
4. implementing your own function or demonstration, after checking with [Ronald Poppe](mailto:r.w.poppe@uu.nl). The number of points depend on your creativity and the level of difficulty.

The maximum score for this assignment is 10 (100 points).

**Deadline**: Sunday September 29, 23:00. One full point will be deducted for submissions within one day of the deadline (you will have to email [Ronald Poppe](mailto:r.w.poppe@uu.nl)). No further extensions to the deadline will be given. There is **no re-take** for the assignments.

**Questions/Contact**: The assistants for this course are available to answer your questions and to provide guidance about your project. Contact them through the [INFOIBV2019 Slack](http://infoibv2019.slack.com/). There are walk-in sessions where the student assistant can help you. Check the Roster page.


  