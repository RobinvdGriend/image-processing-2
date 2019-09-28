# Image processing: Assignment 2

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