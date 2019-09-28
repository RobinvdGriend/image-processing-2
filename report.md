# Image processing: Assignment 2

## Choices Made

- In the case of a binary image, a pixel with value 0 is 'off', all the other pixels [1-255] are 'on'. When performing an operation that returns a binary image (instead of a greyscale image) the values 0 and 255 will strictly be used (and no values in between).

- In the case of the structuring elements two shapes are implemented (+ and ▮/ 4- and 8 neighbourhood). Here the value of 0 for a given location in the bounding box of the shape signifies that this value will not be included in the operation.

- The boundary trace function is implemented using the Moore tracing function. First the 'first pixel' is found by scanning the image, starting from the top left corner in a row first manner. After the first pixel is found the boundary is traced by looking in the 8-neighborhood for adjacent pixels. The stopping criterion is encountering the first pixel, not the first pixel in combination with the direction. Therefore some complex shapes are not traced correctly. This function also only draws the first encountered shape and does not include enclosed shapes. This first encountered shape is than drawn as a bitmap and also written to the output window (View->Output / Ctrl + Alt + O).

  



## Images E1,E2,E3,E4,E5



| Image Name                   | A    | E1   | E2   | E3   | E4   | E5   |
| ---------------------------- | ---- | ---- | ---- | ---- | ---- | ---- |
| **Structuring element size** | N.A  | 3    | 5    | 7    | 9    | 11   |
| **# of values**              | 255  | 250  | 248  | 246  | 244  | 244  |

>  Table: Number of distinct pixel values of image before and after dilations with structuring element with square shape and increasing size.

After applying a dilation, we see a decrease in distinct pixel values in the image. Greyscale dilation is defined on an image $I$ and structuring element $H$ as follows:
$$
(I \oplus H) (u,v) = \max_{(i,j) \in H} \{I(u+i,v+j) + H(i,j)\}
$$
Since this maximum value can be the same in two neighbouring subimages of $I$, two adjacent pixels of different pixel values can end up with the same value. If for example a white pixel is surrounded by a variety of lower valued pixels, these surrounding pixels will all become white as a result of the dilation. This in turn can lead to a loss in the number of pixel values used. This loss will almost entirely be in the lower end of the spectrum

![1569674635664](C:\Users\sam\OneDrive\WorkFiles\Vakken\IBV\Practicals\Assignment 2\assets\1569674635664.png)

> Image: Log Histogram of image E5, a loss of lower intensity values and overexposure are evident.